﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Database.API.DTOs;
using Database.API.Interface;
using Database.API.Models;
using Microsoft.AspNetCore.Mvc;


namespace Database.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WarehouseController : Controller
    {
        WarehouseInterface IWarehouse;

        public WarehouseController(WarehouseInterface warehouse)
        {
            IWarehouse = warehouse;
        }

        [HttpGet("getTypeProduct")]
        public IActionResult getTypeProduct()
        {
            return Ok(IWarehouse.getTypeProduct());
        }

        [HttpGet("getProduct")]
        public IActionResult getProduct()
        {
            return Ok(IWarehouse.getProducts());
        }

        [HttpPost("addProduct")]
        public IActionResult addProduct(Product[] values)
        {
            string result = IWarehouse.addProduct(values);
            return Ok(result);
        }
    }
}
