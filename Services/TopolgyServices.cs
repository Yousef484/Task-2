using System;
using System.Collections.Generic;
using System.Linq;
using Task_2.data;

namespace Task_2.Services
{
    public class TopolgyServices : ITopolgyServices
    {
        private static List <Topology> Topolgies = new List<Topology> ();

        public ServiceResponse<Components> AddComponentInTopology(string topologyID, Components component)
        {
            var serviceResponse = new ServiceResponse <Components> ();
            try{
            Topolgies.First(T => T.ID == topologyID).Components.Add(component);
            serviceResponse.data = component;
            }
            catch(Exception ex){
                serviceResponse.success = false ; 
                serviceResponse.message = "Ther is no such Topogly!";
                return serviceResponse;
                }
           
            return serviceResponse;
        }

        public ServiceResponse<Topology> AddTopology(Topology topology)
        {
            var serviceResponse =new ServiceResponse<Topology>();
            for(int i=0 ; i< Topolgies.Count(); i++){
                if (Topolgies.ElementAt(i).ID ==topology.ID)
                  {
                      serviceResponse.success = false;
                      serviceResponse.message = "This is Topology already exists!, So Add your Data on it";
                      return serviceResponse;
                  }
            } 
            serviceResponse.data = topology;    
            Topolgies.Add(topology); 
            
            return serviceResponse;
        }

        public ServiceResponse<Topology> DeleteTopology(string id)
        {   
            var serviceResponse = new ServiceResponse<Topology>();
            try{ 
            Topology deletedOne = Topolgies.First(   T=> T.ID  == id );
            Topolgies.Remove(deletedOne);
            serviceResponse.data = deletedOne;
            }
            catch(Exception ex){
                serviceResponse.message = "There is no such Topology";
                serviceResponse.success = false ;
                serviceResponse.data = null;
            }
            return serviceResponse;
        }

        public List<Topology> GetAll()
        {
           
            return Topolgies;
        }

        public ServiceResponse<List<Component>> GetAllDevicesInTopo(string topologyID)
        {
            var serviceResponse = new ServiceResponse<List<Component>>();
           try{
            Topology wantedTopo = Topolgies.First( T=> T.ID  == topologyID );
            List<Component> result = new List<Component>();
            for (int i=0 ; i<wantedTopo.Components.Count(); i++){
                result.Add(wantedTopo.Components.ElementAt(i).component);
            }
             serviceResponse.data = result; 
            }
           catch(Exception ex){
               serviceResponse.success  = false ; 
               serviceResponse.message = "There is no such Topology!";
               return serviceResponse;
           } 
          
            return serviceResponse;
           
        }

        public ServiceResponse<Dictionary<String,dynamic>> GetDevicesWithNetList(string topologyID, string netListID)
        {
              var serviceResponse = new ServiceResponse<Dictionary<String,dynamic>>();
              bool found = false;
           try{
              Topology wantedTopo = Topolgies.First(   T=> T.ID  == topologyID );
              for (int i=0 ; i<wantedTopo.Components.Count(); i++){
               if (wantedTopo.Components.ElementAt(i).ID == netListID)
               {
                   serviceResponse.data = wantedTopo.Components.ElementAt(i).netlist;
                   found = true;
                   break;
               }
            }
            }
            catch(Exception ex ){
                serviceResponse.message = "There is no such Topology!";
                serviceResponse.success = false ;
                return serviceResponse;
            }
            if (found ==false )
            {
                serviceResponse.message = "There is no such device!";
                serviceResponse.success = false ;
            }
            
              return serviceResponse;

        }

        public ServiceResponse<Topology> GetTopology(string topologyID)
        {
            var serviceResponse = new ServiceResponse<Topology>();
            try{
            Topology wanted = Topolgies.First(   T=> T.ID  == topologyID );
            serviceResponse.data = wanted;
            }
            catch(Exception ex){
              serviceResponse.message = "There is no such Topology";
              serviceResponse.success = false ;
              serviceResponse.data  = null;
            }
            return serviceResponse;
        }

     
    }
}