using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace z13.forms
{
    public partial class Form1 : Form
    {

        internal abstract class Commodity
        {

            // Дата производства.
            protected DateTime ManufactureDate;

            // Название продукта.
            protected string Name;

            // Цена.
            protected int Price;

            /// Срок годности.
            protected int WorkingLife;

            /// Вывод информации о товаре.
            public virtual string Info()
            {
                return string.Format("Название продукта - {0}\nЦена - {1}", Name, Price);
            }

            /// Соответствие сроку годности.
            /// <param name="currentDate">Текущая дата.</param>
            /// <returns>true, если годен.</returns>
            public virtual bool IsCorrespondsToWorkingLife(DateTime currentDate)
            {
                return (currentDate < ManufactureDate + new TimeSpan(WorkingLife, 0, 0, 0));
            }
        }

        /// Продукт.
        internal class Product : Commodity
        {
            /// Новый продукт.
            /// <param name="name">Название</param>
            /// <param name="price">Цена</param>
            /// <param name="manufactureDate">Дата производства</param>
            /// <param name="workingLife">Срок годности</param>
            public Product(string name, int price, DateTime manufactureDate, int workingLife)
            {
                Name = name;
                Price = price;
                ManufactureDate = manufactureDate;
                WorkingLife = workingLife;
            }

            public override string Info()
            {
                return base.Info() +
                       string.Format("\nДата производства - {0}\nСрок годности - {1} дней",
                                     ManufactureDate, WorkingLife);
            }
        }

        /// Партия.
        internal class Batch : Commodity
        {
            private readonly int _count;

            /// Новая партия.
            /// <param name="name">Название</param>
            /// <param name="price">Цена</param>
            /// <param name="count">Количество.</param>
            /// <param name="manufactureDate">Дата производства</param>
            /// <param name="workingLife">Срок годности</param>
            public Batch(string name, int price, int count, DateTime manufactureDate, int workingLife)
            {
                _count = count;
                Name = name;
                Price = price;
                ManufactureDate = manufactureDate;
                WorkingLife = workingLife;
            }

            public override string Info()
            {
                return base.Info() +
                       string.Format("\nКоличество - {0}\nДата производства - {1}\nСрок годности - {2} дней",
                                     _count, ManufactureDate, WorkingLife);
            }
        }

        /// Комплект.
        internal class Set : Commodity
        {
            private readonly string _list;

            /// Новый комплект.
            /// <param name="name">Название</param>
            /// <param name="price">Цена</param>
            /// <param name="list">Перечень продуктов</param>
            public Set(string name, int price, string list)
            {
                _list = list;
                Name = name;
                Price = price;
            }

            public override string Info()
            {
                return base.Info() +
                       string.Format("\nПеречень продуктов - {0}",
                                     _list);
            }

            // Переопределяем, так как у комплекта бесконечный срок годности.
            public override bool IsCorrespondsToWorkingLife(DateTime currentDate)
            {
                return true;
            }
        }


        public Form1()
        {
            InitializeComponent();
            richTextBox1.Text="";
            List<Commodity> commodities = new List<Commodity>
                                  {
                                      new Product("сыр", 200, Convert.ToDateTime("11.12.2020"), 30),
                                      new Product("яйца", 80, Convert.ToDateTime("02.12.2020"), 10),
                                      new Batch("Чипсы", 30, 4, Convert.ToDateTime("04.06.2019"), 360),
                                      new Batch("альпен гольд", 39, 4, Convert.ToDateTime("05.12.2020"), 21),
                                      new Set("спички", 40, "для камина"),
                                      new Set("жевачка", 50, "мятная")
                                  };

            // Выводим данные и соответствие сроку годности.
            DateTime now = DateTime.Now;
            foreach (Commodity commodity in commodities)
            {
                richTextBox1.Text += (commodity.Info());
                richTextBox1.Text += (commodity.IsCorrespondsToWorkingLife(now) ? "Годен" : "Не годен");
                richTextBox1.Text += Environment.NewLine;
            }
            richTextBox1.Text += Environment.NewLine;
        }

    }
}
