using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace SoundDeviceLib
{
    /// <summary>
    /// Класс, представляющий Звуковоспроизводящие устройства.
    /// </summary>
    public class SoundDevice : Product
    {
        public SoundDevice(string id, string name, int price, string model, string company) : base(id, name, "SoundDevice")
        {
            Price = price;
            Company = company;
            Model = model;
        }
        public int Price { get; set; }
        public string Company { get; set; }
        public string Model { get; set; }


        protected override void GetInfo(StringBuilder sb)
        {
            sb.AppendLine("Цена - " + Price);
            sb.AppendLine("Модель - " + Model);
            sb.AppendLine("Компания - " + Company);
        }

        protected override void GetProductType(StringBuilder sb)
        {
            sb.Append("Тип - SoundDevice");
        }
    }
}