using BarcodeLib;
using SoundDeviceLib;
using System.ComponentModel.DataAnnotations;
using System.Reflection.Metadata.Ecma335;
using System.Text;

namespace ShowcaseLib
{
    /// <summary>
    /// Класс, представляющий витрину товара.
    /// </summary>
    public class Showcase
    {
        private Product[] soundDevice;
        private int _id;

        private Showcase(int size)
        {
            soundDevice = new Product[size];
            ID = new Random().Next(1, 9999);
        }

        public static implicit operator Showcase(int size)
        {
            return new Showcase(size);
        }

        public int ID
        {
            get { return _id; }
            set
            {
                if (_id == 0) { _id = value; }
                else
                {
                    _id = value;
                    UpdateBarcode();
                }
            }
        }



        public Product this[int index]
        {
            get
            {
                if (index >= 0 && index < soundDevice.Length)
                {
                    Product book = soundDevice[index];
                    soundDevice[index] = null;
                    return book;
                }
                return null;
            }
            set
            {
                if (index >= 0 && index < soundDevice.Length)
                {
                    soundDevice[index] = value;
                    UpdateBarcode();
                }
            }
        }

        public void Push(Product book)
        {
            for (int i = 0; i < soundDevice.Length; i++)
            {
                if (soundDevice[i] == null)
                {
                    this[i] = book;
                    //soundDevice[i] = book;
                    //UpdateBarcodee(book, i);
                    return;
                }
            }
        }

        public void Push(int index, Product book)
        {
            if (index >= 0 && index < soundDevice.Length)
            {
                this[index] = book;
                //soundDevice[index] = book;
                //UpdateBarcodee(book, index);
            }
        }

        public void Del(int index)
        {
            this[index] = null;
        }

        public void Replace(int index, Product book)
        {
            if (index >= 0 && index < soundDevice.Length)
            {
                this[index] = book;
                UpdateBarcode();
            }
        }

        public void ChangePosition(int index1, int index2)
        {
            index1--;
            index2--;
            if (index1 >= 0 && index1 < soundDevice.Length && index2 >= 0 && index2 < soundDevice.Length)
            {
                Product tmp = soundDevice[index1];
                soundDevice[index1] = soundDevice[index2];
                soundDevice[index2] = tmp;

                UpdateBarcode();
            }
        }

        public int SearchID(int ID)
        {
            for (int i = 0; i < soundDevice.Length; i++)
            {
                if (soundDevice[i] != null && soundDevice[i].Id.Equals(ID))
                {
                    return i;
                }
            }
            return -1;
        }

        public int SearchName(string name)
        {
            for (int i = 0; i < soundDevice.Length; i++)
            {
                if (soundDevice[i] != null && soundDevice[i].Name.Equals(name, StringComparison.OrdinalIgnoreCase))
                {
                    return i;
                }
            }
            return -1;
        }

        public void SortName()
        {
            Array.Sort(soundDevice, (x, y) => string.Compare(x?.Name, y?.Name, StringComparison.OrdinalIgnoreCase));
            UpdateBarcode();
        }

        public override string ToString()
        {
            string result = $"Витрина ID: {ID}\nТовары: \n";
            for (int i = 0; i < soundDevice.Length; i++)
            {
                result += $"Ячейка {i}: Книга: {(soundDevice[i] != null ? soundDevice[i].Name : "Пусто")}, ID: {(soundDevice[i] != null ? soundDevice[i].Idi : "000000")}\n{(soundDevice[i] != null ? soundDevice[i].Barcode : "")}\n";
            }
            return result;
        }

        private void UpdateBarcode(Product book, Showcase storagese, int index = -1)
        {
            if (book != null)
            {
                // Сбросить штрихкод до ID товара, если это необходимо
                book.Barcode = null;

                if (index != -1) // если индекс задан
                {
                    book.Idi = $"{Convert.ToString(book.Id)} {Convert.ToString(ID)} {Convert.ToString(index + 1)}";
                    book.Barcode = new Barcode(Convert.ToString(book.Idi));
                }
            }
        }

        private void UpdateBarcode()
        {
            for (int i = 0; i < soundDevice.Length; i++)
            {
                UpdateBarcode(soundDevice[i], ID, i);
            }
        }

        //public void ChangeID()
        //{
        //    ID++;
        //    UpdateBarcodee();
        //}
    }
}
