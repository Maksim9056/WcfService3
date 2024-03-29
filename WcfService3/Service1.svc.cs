﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using System.Web.Services.Description;

namespace WcfService3
{
    // ПРИМЕЧАНИЕ. Команду "Переименовать" в меню "Рефакторинг" можно использовать для одновременного изменения имени класса "Service1" в коде, SVC-файле и файле конфигурации.
    // ПРИМЕЧАНИЕ. Чтобы запустить клиент проверки WCF для тестирования службы, выберите элементы Service1.svc или Service1.svc.cs в обозревателе решений и начните отладку.
    public class Service1 : IService1
    {
        public List<Contrack> Services = new List<Contrack>();

        public string AddGet(Contrack contrack)
        {

            Services.Add(contrack);
            return "Добавился";
        }
        public string GetData(int value)
        {
            return string.Format("You entered: {0}", value);
        }

        public string Push(int contrack)
        {
            Contrack contrack1 = Services.Find(find => find.Id == contrack);

            return contrack1.Name_Contrack;
        }

        [DataContract]

        public class Contrack
        {
           [DataMember]

             public int Id { get; set; }
            [DataMember]

            public string Name_Contrack { get; set; }

            public Contrack(int id, string name_Contrack)
            {
                Id = id;
                Name_Contrack = name_Contrack;
            }

        }


        public List<Contrack> ListContrat()
        {

            return Services;
        }
        public CompositeType GetDataUsingDataContract(CompositeType composite)
        {
            if (composite == null)
            {
                throw new ArgumentNullException("composite");
            }
            if (composite.BoolValue)
            {
                composite.StringValue += "Suffix";
            }
            return composite;
        }


    }
}
