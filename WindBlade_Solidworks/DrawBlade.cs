using System;
using System.Collections.Generic;
using System.Windows.Forms;
using SolidWorks.Interop.sldworks;
using SolidWorks.Interop.swconst;

namespace WindowsFormsApplication1
{
    class DrawBlade
    {
        private ModelDoc2 swDoc;
        private SldWorks swApp;
        private readonly List<double> points = new List<double>();

        //создает проект детали
        public void CreateDoc()
        {
            swApp = new SldWorks { Visible = true };
            swApp.NewPart();
            swDoc = swApp.GetFirstDocument();
            swDoc.SketchManager.InsertSketch(true);
        }

        //создание оси
        public void AddCenterLine(double[] points)
        {
            swDoc.SketchManager.CreateCenterLine(points[21], points[22], points[23], points[54], points[55], points[56]);
        }

        //удаление взаимосвязи вертикальности созданной ранее оси
        public void DeleteVertical()
        {
            swDoc.EditSketch();
            swDoc.Extension.SelectByID2("Line1", "SKETCHSEGMENT", 0, 0, 0, false, 0, null, 0);
            swDoc.SketchConstraintsDel(0, "sgVERTICAL2D");
        }

        //создание связи совпадение
        public void AddCoinsident()
        {
            swDoc.Extension.SelectByID2("Point13", "SKETCHPOINT", 0, 0, 0, false, 0, null, 0);
            swDoc.Extension.SelectByID2("Point1@Исходная точка", "EXTSKETCHPOINT", 0, 0, 0, true, 0, null, 0);
            swDoc.SketchAddConstraints("sgCOINCIDENT");
        }

        //создание новой плоскости
        public void AddPlane(int planeNum, double offset)
        {
            swDoc.SketchManager.InsertSketch(true);
            swDoc.Extension.SelectByID2("Спереди", "PLANE", 0, 0, 0, true, 0, null, 0);
            swDoc.FeatureManager.InsertRefPlane(8, offset, 0, 0, 0, 0);
            swDoc.Extension.SelectByID2("Плоскость" + planeNum.ToString(), "PLANE", 0, 0, offset, false, 0, null, 0);
            swDoc.SketchManager.InsertSketch(true);
        }

        //создание точки
        public double[] AddPoint(double X, double Y)
        {
            var point = new double[3];
            point[0] = X;
            point[1] = Y;
            point[2] = 0;
            return point;
        }

        //заполнение массива точек
        public void PointList(double[] point)
        {
            foreach (var p in point)
                points.Add(p);
        }

        //очистить массив точек
        public void ClearPoints()
        {
            points.Clear();
        }

        //получить все координаты точек
        public double[] GetPoints()
        {
            return points.ToArray();
        }

        //создание линии
        public void DrawSpline(double[] points)
        {
            (swDoc.SketchManager.CreateSpline(points) as ISketchSpline).Proportional = true;
        }

        //удаление взаимосвязи совпадение
        public void RemoveCoincident()
        {
            swDoc.Extension.SelectByID2("Неизвестный", "MANIPULATOR", 0.00086662543327636898, -0.0046220023108073105, 0, false, 0, null, 0);
            swDoc.EditDelete();
            swDoc.SketchConstraintsDel(1, "sgCOINCIDENT");
            swDoc.Extension.SelectByID2("Неизвестный", "MANIPULATOR", 0.00086662543327636898, -0.0046220023108073105, 0, false, 0, null, 0);
            swDoc.EditDelete();
            swDoc.SketchConstraintsDel(1, "sgCOINCIDENT");
        }

        //позиционирование скетча по середине
        public void SketchToCenter(int indexSketch)
        {
            swDoc.Extension.SelectByID2("Point26", "SKETCHPOINT", 0, 0, 0, false, 0, null, 0);
            swDoc.Extension.SelectByID2("Point1@Исходная точка", "EXTSKETCHPOINT", 0, 0, 0, true, 0, null, 0);
            swDoc.AddDimension2(0, 0, 0);
            var dimension = swDoc.Parameter("D2@Эскиз" + (indexSketch + 2).ToString());
            dimension.SystemValue = 0.01;
        }

        //поворот эскиза на угол
        public void RotateToDegree(double degree, int indexSketch)
        {
            swDoc.SketchManager.CreateCenterLine(0.000000, 0.000000, 0.000000, 1, 0.000000, 0.000000);
            swDoc.Extension.SelectByID2("Line2", "SKETCHSEGMENT", 0.5, 0, 0, false, 0, null, 0);
            swDoc.Extension.SelectByID2("Line1", "SKETCHSEGMENT", -0.1, 0, 0, true, 0, null, 0);
            swApp.SetUserPreferenceToggle((int)swUserPreferenceToggle_e.swInputDimValOnCreate, false);
            swDoc.AddDimension(-0.1, 0.1, 0);
            var dimension = swDoc.Parameter("D1@Эскиз" + (indexSketch + 2).ToString());
            dimension.SystemValue = (degree * (180 / Math.PI) + 90) / 100;
        }

        //создание бобышки по сечениям
        public void CreateBlend(double[] offset)
        {
            var count = 0;
            foreach (var o in offset)
            {
                swDoc.Extension.SelectByID2("Эскиз" + (count + 1).ToString(), "SKETCH", 0, 0, o, true, 0, null, 0);
                count++;
            }
            swDoc.FeatureManager.InsertProtrusionBlend(false, true, false, 1, 6, 6, 1, 1, true, true, false, 0, 0, 0, true, true, true);
        }

        //создание центральной бобышки
        public void CenterCircle(double radius)
        {
            swDoc.Extension.SelectByID2("Сверху", "PLANE", 0, 0, 0, false, 0, null, 0);
            swDoc.SketchManager.CreateCircle(0, radius / 2, 0, radius / 2, radius / 2, 0);
            swDoc.Extension.SelectByID2("Arc1", "SKETCHSEGMENT", 0, 0, 0, true, 0, null, 0);
            swDoc.FeatureManager.FeatureExtrusion2(false, false, false, 0, 0, radius / 3, radius / 8, false, false, false, false, 0, 0, false, false, false, false, true, true, true, 0, 0, false);
            swDoc.Extension.SelectByID2("Сверху", "PLANE", 0, 0, 0, false, 0, null, 0);
            swDoc.SketchManager.CreateCircle(0, radius / 2, 0, 0.1, 0.25, 0);
            swDoc.Extension.SelectByID2("Arc1", "SKETCHSEGMENT", 0, 0, 0, false, 0, null, 0);
            swDoc.FeatureManager.FeatureCut3(false, false, false, 1, 1, 0.01, 0.01, false, false, false, false, 0, 0, false, false, false, false, false, true, true, true, true, false, 0, 0, false);
        }

        //выбор первой плоскости для последнего эскиза
        public void SelectFront()
        {
            swDoc.Extension.SelectByID2("Спереди", "PLANE", 0, 0, 0, true, 0, null, 0);
        }

        //создание бобышка вытянутая до тела
        public void ConnectOnCircle()
        {
            swDoc.Extension.SelectByID2("Вырез-Вытянуть1", "SOLIDBODY", 0.23142756643278517, 0.033607452404311289, -0.42553915207622595, false, 1, null, 0);
            swDoc.FeatureManager.FeatureExtrusion2(true, false, true, 7, 0, 0.01, 0.01, false, false, false, false, 0.017453292519943334, 0.017453292519943334, false, false, false, false, true, true, true, 0, 0, false);
            swDoc.ISelectionManager.EnableContourSelection = false;
        }

        //массив по кругу
        public void AddMirror(int count)
        {
            swDoc.Extension.SelectByID2("Бобышка-Вытянуть2", "BODYFEATURE", 0.17, 0.072, -0.026, false, 4, null, 0);
            swDoc.Extension.SelectByID2("По сечениям1", "BODYFEATURE", 0.10, 0.06, 0.18, true, 4, null, 0);
            swDoc.Extension.SelectByID2("", "FACE", 0.26, 0.03, -0.19, true, 1, null, 0);
            swDoc.FeatureManager.FeatureCircularPattern4(count, 6.2831853071796004, false, "NULL", true, true, false);
        }

        //фаска
        public void AddChamfer()
        {
            swDoc.Extension.SelectByID2("", "FACE", 0.0099485373947345579, 0.18379999999984875, -0.11005668693366033, false, 0, null, 0);
            swDoc.FeatureManager.InsertFeatureChamfer(6, 1, 0.02, 0.78539816339745006, 0, 0, 0, 0);
        }
    }
}