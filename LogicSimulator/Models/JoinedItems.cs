using Avalonia.Controls.Shapes;
using Avalonia.Media;
using System.Collections.Generic;

namespace LogicSimulator.Models {
    public class JoinedItems {
        public Line line = new() { Tag = "Join", ZIndex = 2, Stroke = Brushes.DarkGray, StrokeThickness = 3 };
        public static readonly Dictionary<Line, JoinedItems> arrow_to_join = new(); // объект для связывания двух элементов линией
        public void Update()
        {
            line.StartPoint = A.GetPos();
            line.EndPoint = B.GetPos();
        }
        public void Delete()
        {
            arrow_to_join.Remove(line);
            line.Remove();
            A.parent.RemoveJoin(this);
            B.parent.RemoveJoin(this);
        }
        public Distantor A { get; set; }
        public Distantor B { get; set; }
        public JoinedItems(Distantor a, Distantor b) {  
            A = a; B = b; Update(); // устанавливает начало и конец линии на позиции элементов A и B
            a.parent.AddJoin(this); 
            if (a.parent != b.parent) b.parent.AddJoin(this);
            arrow_to_join[line] = this;
        }
    }
}
