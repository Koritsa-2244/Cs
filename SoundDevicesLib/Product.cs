using BarcodeLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace SoundDeviceLib
{
    /// <summary>
    /// Абстрактный класс, представляющий товар.
    /// </summary>
    public abstract class Product
    {
        private string _id;//самого устройства
        private string _idi;//товара (полка, место)
        public Product(string id, string name, string description)
        {
            Id = id;//создание id товара
            Name = name;//название товара
            Description = description;//Описание товара (тип устройства)
        }
        public string Idi//создание id для товара
        {
            get { return _idi; }
            set
            {
                _idi = value;
                Barcode = new Barcode(value.ToString());
            }
        }

        public string Id//создание id для устройства
        {
            get { return _id; }
            set
            {
                _id = value;
                Barcode = new Barcode(value.ToString());
            }
        }
        public string Name { get; set; }
        public string Description { get; set; }
        public Barcode Barcode { get; set; }

        protected abstract void GetInfo(StringBuilder sb);
        protected abstract void GetProductType(StringBuilder sb);
        public override string ToString()
        {
            var sb = new StringBuilder();
            GetProductType(sb);
            sb.AppendLine($"Название -  {Name}");
            GetInfo(sb);
            sb.AppendLine(Barcode.ToString());
            return sb.ToString();

        }
    }
}