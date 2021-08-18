using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace c5.Controllers
{
    [Route("api/warehouses")]
    [ApiController]
    public class WarehousesController : ControllerBase
    {
        //add DBD service
        private readonly IDBService _DBService;
        public WarehousesController(IDBService DB)
        {
           _DBService = DB
        }

        [HttpPost]
        public async Task<IActionResult> PostProduct(WareHouses warehouse)
        {          
            Warehouse product = await _DBService.CheckIfProductWarehouseExistAsync(warehouse);
            //1
            if (((product._IdProduct != warehouse._IdProduct) && (product._IdWarehouse != warehouse._IdWarehouse)))
                return NotFound("Product with such ID doesn't exist");
            //2
            int IdOrder = await _DBService.GetOrdersAsync(warehouse);
            if (IdOrder == -1)
                return NotFound("The order does not exist");            
            //3
            if ((await _DBService.CheckIfOrderAlreadyProcessedAsync(warehouse, IdOrder)))
                return NotFound("Order with such ID already commpleted");
            //4
            await _DBService.UpdateFullfilledAtAsync(warehouse, IdOrder);
            //5
            int res =await _DBService.InsertRecordToProductWarehouseAsync(warehouse, IdOrder);
            Console.WriteLine(res);

            return Ok(product);
        }
    }
}
