using System;
using System.Collections.Generic;
using System.Text;
using DAL.Models;
using DataObject.Models;

namespace DataObject
{
    public class Auto:AutoMapper.Profile
    {
        public Auto()
        {
            //ממיר למוצרים
            CreateMap<ProductDTO, Products>();
            CreateMap<Products, ProductDTO>();
            //ממיר למלקטים
            CreateMap<CollectorDTO, Collector>();
            CreateMap<Collector, CollectorDTO>();
            //ממיר למחסנים
            CreateMap<Storage, StorageDTO>();
            CreateMap<StorageDTO, Storage>();
            //ממיר למוצרים בהזמנה
            CreateMap<ProductsOnOrder, ProductsOnOrderDTO>();
            CreateMap<ProductsOnOrderDTO, ProductsOnOrder>();
            //ממיר לקבוצת מוצרים
            CreateMap<ProductGroups, ProductGroupsDTO>();
            CreateMap<ProductGroupsDTO, ProductGroups>();
            //ממיר לדגם מוצר
            CreateMap<ProductModelsDTO, ProductModels>();
            CreateMap<ProductModels, ProductModelsDTO>();
            //ממיר לצבעים
            CreateMap<Colors, ColorsDTO>();
            CreateMap<ColorsDTO, Colors>();
            //ממיר להזמנות
            CreateMap<Orders, OrdersDTO>();
            CreateMap<OrdersDTO, Orders>();
        }
    }
}
