using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace lab_oop_7
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }


        int p = 0;
        static int k = 5;
        Storage storag = new Storage(k);
        static int index = 0;
        int indexin = 0;
        int figure_now = 0;

        class Figure
        {
            public int x, y;
            public Color color = Color.Navy;
            public Color fillcolor = Color.White;
        }
        class Circle : Figure
        {
            //public int x, y; // Координаты круга
            public int rad = 15; // Радиус круга
            public Circle(int x, int y)
            {
                this.x = x - rad;
                this.y = y - rad;
            }

            ~Circle() { }
        }

        class Line : Figure
        {
            //public int x, y;
            public int lenght = 60;
            public int wight = 5;
            public Line(int x, int y)
            {
                this.x = x - lenght / 2;
                this.y = y;
            }
        }

        class Storage
        {
            public Figure[] objects;
            public Storage(int count)
            {
                objects = new Figure[count];
                for (int i = 0; i < count; ++i)
                    objects[i] = null;
            }
            public void initialisat(int count)
            {//выделяем место
                objects = new Figure[count];
                for (int i = 0; i < count; ++i)
                    objects[i] = null;
            }
            public void add_object(int ind, ref Figure object1, int count, ref int indexin)
            {//добавляет объект
                while (objects[ind] != null)
                {//если ячейка занята, ищем новое место
                    ind = (ind + 1) % count;
                }
                objects[ind] = object1;
                indexin = ind;
            }
            public void delete_object(int ind)
            {//удаляет объект из хранилища
                objects[ind] = null;
                index--;
            }
            public bool check_empty(int index)
            {//занято ли место
                if (objects[index] == null)
                    return true;
                else
                    return false;
            }
            public int occupied(int size)
            {//кол-во занятых мест
                int count_occupied = 0;
                for (int i = 0; i < size; ++i)
                    if (!check_empty(i))
                        ++count_occupied;
                return count_occupied;
            }
            public void increase(ref int size)
            {//расширение хранилища
                Storage storage1 = new Storage(size + 10);
                for (int i = 0; i < size; ++i)
                    storage1.objects[i] = objects[i];
                for (int i = size; i < (size + 10) - 1; ++i)
                {
                    storage1.objects[i] = null;
                }
                size = size + 10;
                initialisat(size);
                for (int i = 0; i < size; ++i)
                    objects[i] = storage1.objects[i];
            }
            ~Storage() { }
        };

        private void paint_figure(Color name, ref Storage stg, int index)
        {//рисуем круг на панели
            Pen pen = new Pen(name, 4);
            SolidBrush figurefillcolor;
            if (!stg.check_empty(index))
            {
                stg.objects[index].color = name;
                figurefillcolor = new SolidBrush(stg.objects[index].fillcolor);
                if (storag.objects[index] as Circle != null)
                {// Если в хранилище круг
                    Circle circle = stg.objects[index] as Circle;
                    paint_box.CreateGraphics().DrawEllipse(
                    pen, circle.x, circle.y, circle.rad * 2, circle.rad * 2);
                    paint_box.CreateGraphics().FillEllipse(
                        figurefillcolor, circle.x, circle.y, circle.rad * 2, circle.rad * 2);
                }
                else if (stg.objects[index] as Line != null)
                {   // Если в хранилище линия
                    Line line = stg.objects[index] as Line;
                    paint_box.CreateGraphics().DrawRectangle(pen, line.x,
                                            line.y, line.lenght, line.wight);
                    paint_box.CreateGraphics().FillRectangle(figurefillcolor, line.x,
                        line.y, line.lenght, line.wight);
                }

            }
        }

        private void button_del__item_storage_Click(object sender, EventArgs e)
        {
            remove_selected_circle(ref storag);
            paint_box.Refresh();
            if (storag.occupied(k) != 0)
            {
                for (int i = 0; i < k; ++i)
                {
                    paint_figure(Color.Navy, ref storag, i);
                }
            }
        }

        private void remove_selected_circle(ref Storage stg)
        {//удаляет выделенные элементы
            for (int i = 0; i < k; ++i)
            {
                if (!stg.check_empty(i))
                {
                    if (stg.objects[i].color == Color.Red)
                    {
                        stg.delete_object(i);
                    }
                }
            }
        }

        private void paint_box_MouseClick(object sender, MouseEventArgs e)
        {
            //проверка на наличие круга на данных координатах
            int c = check_figure(ref storag, k, e.X, e.Y);
            if (index == k)
                storag.increase(ref k);
            if (c != -1)
            {//круг уже есть
                if (Control.ModifierKeys == Keys.Control)
                {//если нажат, выделяем несколько объектов
                    if (p == 0)
                    {
                        paint_figure(Color.Navy, ref storag, indexin);
                        p = 1;
                    }
                    paint_figure(Color.Red, ref storag, c);
                }
                else
                {//иначе только один объект
                    remove_selection_circle(ref storag);

                    paint_figure(Color.Red, ref storag, c);
                }
                return;
            }
            else
            {//круга нет
                Figure figure = new Figure();
                switch (figure_now)
                {   // В зависимости какая фигура выбрана
                    case 0:
                        return;
                    case 1:
                        figure = new Circle(e.X, e.Y);
                        break;
                    case 2:
                        figure = new Line(e.X, e.Y);
                        break;
                }
                storag.add_object(index, ref figure, k, ref indexin);

                remove_selection_circle(ref storag);
                storag.objects[indexin].fillcolor = colorDialog1.Color;
                paint_figure(Color.Red, ref storag, indexin);
                ++index;

            }
            p = 0;
        }

        private int check_figure(ref Storage stg, int size, int x, int y)
        {//проверка на наличие круга с координатами в хранилище
            if (stg.occupied(size) != 0)
            {
                for (int i = 0; i < size; ++i)
                {
                    if (!stg.check_empty(i))
                    {
                        if (stg.objects[i] as Circle != null)
                        {
                            Circle circle = stg.objects[i] as Circle;
                            if (((x - circle.x - circle.rad) * (x - circle.x - circle.rad) + (y - circle.y - circle.rad) * (y - circle.y - circle.rad)) < (circle.rad * circle.rad))
                                return i;
                        }
                        else if (stg.objects[i] as Line != null)
                        {
                            Line line = stg.objects[i] as Line;
                            if (line.x <= x && x <= (line.x + line.lenght) && (line.y - 2) <= y && y <= (line.y + line.wight))
                                return i;
                        }



                    }
                }
            }
            return -1;
        }

        private void remove_selection_circle(ref Storage stg)
        {//снимает выделение
            for (int i = 0; i < k; ++i)
            {
                if (!stg.check_empty(i))
                {
                    paint_figure(Color.Navy, ref storag, i);
                }
            }
        }


        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {//кнопка Delete
            if (e.KeyCode == Keys.Delete)
            {
                remove_selected_circle(ref storag);
                paint_box.Refresh();
                if (storag.occupied(k) != 0)
                {
                    for (int i = 0; i < k; ++i)
                    {
                        paint_figure(Color.Navy, ref storag, i);
                    }
                }
            }
            if (e.KeyCode == Keys.Oemplus)
            {   // Увеличиваем размер фигуры
                changesize(ref storag, 1);
                paint_box.Refresh();
                for (int i = 0; i < k; ++i)
                    if (!storag.check_empty(i))
                        paint_figure(storag.objects[i].color, ref storag, i);
            }
            if (e.KeyCode == Keys.OemMinus)
            {   // Уменьшаем размер фигуры
                changesize(ref storag, -1);
                paint_box.Refresh();
                for (int i = 0; i < k; ++i)
                    if (!storag.check_empty(i))
                        paint_figure(storag.objects[i].color, ref storag, i);
            }
            if (e.KeyCode == Keys.W)
            {   // Перемещение по оси X вверх
                move_y(ref storag, -10);
            }
            if (e.KeyCode == Keys.S)
            {   // Перемещение по оси X вниз
                move_y(ref storag, +10);
            }
            if (e.KeyCode == Keys.A)
            {   // Перемещение по оси Y вниз
                move_x(ref storag, -10);
            }
            if (e.KeyCode == Keys.D)
            {   // Перемещение по оси Y вверх
                move_x(ref storag, +10);
            }
            paint_box.Refresh();
            paint_all(ref storag);
        }

        private void paint_all(ref Storage stg)
        {   // Рисует все фигуры на панели
            for (int i = 0; i < k; ++i)
                if (!stg.check_empty(i))
                    paint_figure(stg.objects[i].color, ref storag, i);
        }

        private void drawellipse_Click(object sender, EventArgs e)
        {
            figure_now = 1;
        }

        private void drawline_Click(object sender, EventArgs e)
        {
            figure_now = 2;
        }

        private void button_color_Click(object sender, EventArgs e)
        {
            if (colorDialog1.ShowDialog() == DialogResult.Cancel)
                return;
            button_color.BackColor = colorDialog1.Color;
            for (int i = 0; i < k; ++i)
            {
                if (!storag.check_empty(i))
                    if (storag.objects[i].color == Color.Red)
                    {
                        storag.objects[i].fillcolor = colorDialog1.Color;
                        paint_figure(storag.objects[i].color, ref storag, i);
                    }
            }


        }

        private void changesize(ref Storage stg, int size)
        {   // Увеличивает или уменьшает размер фигур, в зависимости от size
            for (int i = 0; i < k; ++i)
            {
                if (!stg.check_empty(i))
                {   // Если под i индексом в хранилище есть объект
                    if (stg.objects[i].color == Color.Red)
                    {
                        if (stg.objects[i] as Circle != null)
                        {   // Если в хранилище круг
                            Circle circle = stg.objects[i] as Circle;
                            circle.rad += size;
                        }
                        else if (stg.objects[i] as Line != null)
                        {   // Если в хранилище отрезок
                            Line line = stg.objects[i] as Line;
                            line.lenght += size;
                            //line.wight += size / 5;
                        }

                    }
                }
            }
        }

        private void move_y(ref Storage stg, int y)
        {   // Функция для перемещения фигур по оси Y
            for (int i = 0; i < k; ++i)
            {
                if (!stg.check_empty(i))
                {
                    if (stg.objects[i].color == Color.Red)
                    {   // Если объект выделен
                        if (stg.objects[i] as Circle != null)
                        {   // Если в хранилище круг
                            Circle circle = stg.objects[i] as Circle;
                            int c = circle.y + y;
                            int gran = paint_box.ClientSize.Height - circle.rad * 2;
                            // Проверяем на выход из границы поля
                            check(c, y, gran, gran - 2, ref stg.objects[i], 2);
                        }
                        else
                        {
                            if (stg.objects[i] as Line != null)
                            {   // Если в хранилище отрезок
                                Line line = stg.objects[i] as Line;
                                int l = line.y + y;
                                int gran = paint_box.ClientSize.Height - line.wight;
                                // Проверяем на выход из границы поля
                                check(l, y, gran, --gran, ref stg.objects[i], 2);
                            }

                        }
                    }
                }
            }
        }

        private void move_x(ref Storage stg, int x)
        {   // Функция для перемещения фигур по оси X
            for (int i = 0; i < k; ++i)
            {
                if (!stg.check_empty(i))
                {
                    if (stg.objects[i].color == Color.Red)
                    {   // Если объект выделен
                        if (stg.objects[i] as Circle != null)
                        {   // Если в хранилище круг
                            Circle circle = stg.objects[i] as Circle;
                            int c = circle.x + x;
                            int gran = paint_box.ClientSize.Width - (circle.rad * 2);
                            // Проверяем на выход из границы поля
                            check(c, x, gran, gran - 2, ref stg.objects[i], 1);
                        }
                        else
                        {
                            if (stg.objects[i] as Line != null)
                            {   // Если в хранилище отрезок
                                Line line = stg.objects[i] as Line;
                                int l = line.x + x;
                                int gran = paint_box.ClientSize.Width - line.lenght;
                                // Проверяем на выход из границы поля
                                check(l, x, gran, --gran, ref stg.objects[i], 1);
                            }

                        }
                    }
                }
            }
        }

        private void check(int f, int y, int gran, int gran1, ref Figure figures, int g)
        {   // Проверка на выход фигуры за границы
            ref int b = ref figures.x;
            if (g == 2)
                b = ref figures.y;
            if (f > 0 && f < gran)
                b += y;
            else
            {
                if (f <= 0)
                    b = 1;
                else
                    if (f >= gran1)
                    b = gran1;
            }
        }

    }
}
