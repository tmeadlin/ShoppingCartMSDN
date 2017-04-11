using System;
using System.Collections.Generic;
using System.Text;
using Autofac;
using AzureDocumentDb.Manager;
using Core.Interfaces;

namespace AzureDocumentDb.IoC
{
    public class AutofacModule : Module
    {
        private const string ProductCollectionName = "ProductCollection";
        private const string CartCollectionName = "CartCollection";

        protected override void Load(ContainerBuilder builder)
        {
            //Instantiate the Client
            builder.RegisterType<AzureDocClient>().As<IAzureDocClient>().SingleInstance();

            //Instantiate the DB
            builder.RegisterType<AzureDocDatabase>().As<IAzureDocDatabase>().SingleInstance();

            builder.RegisterType<ProductCollection>().As<IProductCollection>().WithParameter("collectionName", ProductCollectionName).As<IStartable>().SingleInstance();
            builder.RegisterType<CartCollection>().As<ICartCollection>().WithParameter("collectionName", CartCollectionName).As<IStartable>().SingleInstance();

            builder.RegisterType<ProductStorageManager>().As<IProductStorage>().SingleInstance();
            builder.RegisterType<CartStorageManager>().As<ICartStorage>().SingleInstance();
        }
    }
}
