using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RevitAPI_Lab2._1
{
    [Transaction(TransactionMode.Manual)]
    public class Main : IExternalCommand
    {
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            UIApplication uiapp = commandData.Application;
            UIDocument uidoc = uiapp.ActiveUIDocument;
            Document doc = uidoc.Document;

            var vents = new FilteredElementCollector(doc)
            .OfClass(typeof(FilledRegion))
            .Cast<FilledRegion>()
            .ToList();


            TaskDialog.Show("Количество воздуховодов", vents.Count.ToString());

            return Result.Succeeded;
        }
    }
}
