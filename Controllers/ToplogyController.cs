using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Task_2.data;
using Task_2.Services;

namespace Task_2.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ToplogyController : ControllerBase
    {
        public ITopolgyServices _topolgy ;
        public ToplogyController(ITopolgyServices topolgy)
        {
            _topolgy = topolgy;

        }

        [HttpGet("Get All Topolgies")]
         public ActionResult<List<Topology>> GetAll()
        {
            
           if(_topolgy.GetAll().Count == 0)
           return Ok("The List is empty");

           else 
           return Ok(_topolgy.GetAll());
           
        }

        [HttpGet ("Get Toplogy{topolgyID}")]
         public ActionResult<ServiceResponse<Topology>> GetTopolgy(string topolgyID)
        {
            var response = _topolgy.GetTopology(topolgyID);
            if (response.success == true){
               
                return Ok(response.data);
            }
            else
             return NotFound(response.message); 
        }
    
        [HttpGet("Get Topolgy's Devices with ID {topolgyID}")]
        public ActionResult<ServiceResponse<Component>> GetAllDevicesInTopo(string topolgyID){
            var response = _topolgy.GetAllDevicesInTopo(topolgyID);
            if (response.success == true){
                return Ok(response.data);
            }
            else {
                return NotFound(response.message);
            }
        }
      
        [HttpGet("Get Connected Devices with NetList {topolgyID} {netListID}")]
        public ActionResult<ServiceResponse<Dictionary<String,String>>> GetDevicesWithNetList (string topolgyID , string netListID){
           var response = _topolgy.GetDevicesWithNetList(topolgyID,netListID);
           if (response.success == true){
               return Ok(response.data);
           }
           else {
               return NotFound(response.message);
           }
        }

        [HttpPost]
        public ActionResult<ServiceResponse<Topology>> AddTopolgy(Topology topolgy){
            var response = _topolgy.AddTopology(topolgy);
            if (response.success == true){
                return Ok (response.data);
            }
            else {
                return NotFound(response.message);
            }
        }
        
        [HttpPost("Add Component in Topolgy {topolgyID} {component}")]
        public ActionResult <ServiceResponse<Components>> AddComponentInToplogy(string topolgyID, Components component){
          var response = _topolgy.AddComponentInTopology(topolgyID, component);
          if (response.success == true){
              return Ok(response.data);
          }
          else 
          return NotFound(response.message);
        }
      

        [HttpDelete]
        public ActionResult<ServiceResponse<Topology>> DeleteTopogly(string id){
            var response = _topolgy.DeleteTopology(id);
            if (response.success == true){
                return Ok(response.data);
            }
            else 
            return NotFound(response.message);
        }



    }
}