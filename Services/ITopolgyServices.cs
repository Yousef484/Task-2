using System;
using System.Collections.Generic;
using Task_2.data;

namespace Task_2.Services
{
    public interface ITopolgyServices
    {
        ServiceResponse<Topology> AddTopology(Topology topology);
        ServiceResponse<Topology> GetTopology (string topologyID);
        List <Topology> GetAll();
        ServiceResponse<Components> AddComponentInTopology (String topologyID , Components component);
        ServiceResponse<Topology> DeleteTopology(string id);
        ServiceResponse <List <Component>> GetAllDevicesInTopo(string topologyID);
        ServiceResponse<Dictionary<String,dynamic>> GetDevicesWithNetList (string topologyID , string netListID);

    }
}