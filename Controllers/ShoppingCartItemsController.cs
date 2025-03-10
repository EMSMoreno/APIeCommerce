﻿using APIeCommerce.Context;
using APIeCommerce.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace APIeCommerce.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShoppingCartItemsController : ControllerBase
    {
        private readonly AppDbContext _appDbContext;

        public ShoppingCartItemsController(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        // GET: api/ShoppingCartItems/1
        [HttpGet("{userId}")]
        public async Task<IActionResult> Get(int userId)
        {
            var user = await _appDbContext.Users.FindAsync(userId);

            if (user is null)
            {
                return NotFound($"User with id = {userId} not found.");
            }

            var shoppingCartItems = await (from s in _appDbContext.ShoppingCartItems.Where(s => s.ClientId == userId)
                                           join p in _appDbContext.Products on s.ProductId equals p.Id
                                           select new
                                           {
                                               Id = s.Id,
                                               Price = s.UnitPrice,
                                               Total = s.Total,
                                               Quantity = s.Quantity,
                                               ProductId = p.Id,
                                               ProductName = p.Name,
                                               UrlImage = p.UrlImage
                                           }).ToListAsync();

            return Ok(shoppingCartItems);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] ShoppingCartItem shoppingCartItem)
        {
            try
            {
                var shoppingCart = await _appDbContext.ShoppingCartItems.FirstOrDefaultAsync(s =>
                s.ProductId == shoppingCartItem.ProductId &&
                s.ClientId == shoppingCartItem.ClientId);

                if (shoppingCart != null)
                {
                    shoppingCart.Quantity += shoppingCartItem.Quantity;
                    shoppingCart.Total = shoppingCart.UnitPrice * shoppingCart.Quantity;
                }
                else
                {
                    var product = await _appDbContext.Products.FindAsync(shoppingCartItem.ProductId);

                    var cart = new ShoppingCartItem()
                    {
                        ClientId = shoppingCartItem.ClientId,
                        ProductId = shoppingCartItem.ProductId,
                        UnitPrice = shoppingCartItem.UnitPrice,
                        Quantity = shoppingCartItem.Quantity,
                        Total = (product!.Price) * (shoppingCartItem.Quantity)
                    };

                    _appDbContext.ShoppingCartItems.Add(cart);
                }

                await _appDbContext.SaveChangesAsync();
                return StatusCode(StatusCodes.Status201Created);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "An error occurred while processing the request.");
            }
        }

        [Authorize]
        [HttpPut("[action]{productId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> IncreaseQuantity(int productId)
        {
            var userEmail = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Email)?.Value;
            var user = await _appDbContext.Users.FirstOrDefaultAsync(u => u.Email == userEmail);

            if (user == null)
            {
                return NotFound("User not found.");
            }

            var shoppingCartItem = await _appDbContext.ShoppingCartItems.FirstOrDefaultAsync(s =>
            s.ClientId == user.Id && s.ProductId == productId);

            if (shoppingCartItem != null)
            {
                shoppingCartItem.Quantity += 1;
                shoppingCartItem.Total = shoppingCartItem.UnitPrice * shoppingCartItem.Quantity;
                _appDbContext.Update(shoppingCartItem);
                await _appDbContext.SaveChangesAsync();
                return Ok("The quantity was increased successfully.");
            }
            else
            {
                return NotFound("No items found in cart.");
            }
        }

        [Authorize]
        [HttpPut("[action]{productId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> DecreaseQuantity(int productId)
        {
            var userEmail = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Email)?.Value;
            var user = await _appDbContext.Users.FirstOrDefaultAsync(u => u.Email == userEmail);

            if (user == null)
            {
                return NotFound("User not found.");
            }

            var shoppingCartItem = await _appDbContext.ShoppingCartItems.FirstOrDefaultAsync(s =>
            s.ClientId == user.Id && s.ProductId == productId);

            if (shoppingCartItem != null)
            {
                if(shoppingCartItem.Quantity > 1)
                {
                    shoppingCartItem.Quantity -= 1;
                }
                else
                {
                    _appDbContext.ShoppingCartItems.Remove(shoppingCartItem);
                    await _appDbContext.SaveChangesAsync();
                    return Ok("Item removed successfully.");
                }

                shoppingCartItem.Total = shoppingCartItem.UnitPrice * shoppingCartItem.Quantity;
                _appDbContext.Update(shoppingCartItem);
                await _appDbContext.SaveChangesAsync();
                return Ok("The quantity was decreased successfully.");
            }
            else
            {
                return NotFound("No items found in cart.");
            }
        }

        // PUT /api/ShoppingCartItems?produtoId = 1 & acao = "aumentar"
        // PUT /api/ShoppingCartItems?produtoId = 1 & acao = "diminuir"
        // PUT /api/ShoppingCartItems?produtoId = 1 & acao = "apagar"
        [HttpPut]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Put(int productId, string action)
        {
            // Este codigo recupera o endereço de e-mail do user autenticado do token JWT decodificado,
            // Claims representa as declarações associadas ao user autenticado
            // Apenas os users com autenticação podem aceder a este endpoint
            var userEmail = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Email)?.Value;

            var user = await _appDbContext.Users.FirstOrDefaultAsync(u => u.Email == userEmail);

            if (user is null)
            {
                return NotFound("User not found.");
            }

            var shoppingCartItem = await _appDbContext.ShoppingCartItems.FirstOrDefaultAsync(s =>
                                                   s.ClientId == user!.Id && s.ProductId == productId);

            if (shoppingCartItem != null)
            {
                if (action.ToLower() == "increase")
                {
                    shoppingCartItem.Quantity += 1;
                }
                else if (action.ToLower() == "decrease")
                {
                    if (shoppingCartItem.Quantity > 1)
                    {
                        shoppingCartItem.Quantity -= 1;
                    }
                    else
                    {
                        _appDbContext.ShoppingCartItems.Remove(shoppingCartItem);
                        await _appDbContext.SaveChangesAsync();
                        return Ok();
                    }
                }
                else if (action.ToLower() == "delete")
                {
                    // Removes item from cart
                    _appDbContext.ShoppingCartItems.Remove(shoppingCartItem);
                    await _appDbContext.SaveChangesAsync();
                    return Ok();
                }
                else
                {
                    return BadRequest("Invalid Action. Use: 'increase', 'decrease', or 'delete' to perform an action.");
                }

                shoppingCartItem.Total = shoppingCartItem.UnitPrice * shoppingCartItem.Quantity;
                await _appDbContext.SaveChangesAsync();
                return Ok($"Operation : {action} successful.");
            }
            else
            {
                return NotFound("No items found in cart.");
            }
        }

        [Authorize]
        [HttpDelete("{productId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete(int productId)
        {
            var userEmail = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Email)?.Value;
            var user = await _appDbContext.Users.FirstOrDefaultAsync(u => u.Email == userEmail);

            if (user == null)
            {
                return NotFound("User not found.");
            }

            var shoppingCartItem = await _appDbContext.ShoppingCartItems.FirstOrDefaultAsync(s =>
            s.ClientId == user.Id && s.ProductId == productId);

            if (shoppingCartItem != null)
            {
                _appDbContext.ShoppingCartItems.Remove(shoppingCartItem);
                await _appDbContext.SaveChangesAsync();
                return Ok("Item removed successfully.");
            }
            else
            {
                return NotFound("No items found in cart.");
            }
        }
    }
}