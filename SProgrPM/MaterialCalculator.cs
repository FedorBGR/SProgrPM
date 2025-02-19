using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SProgrPM
{
    public class MaterialCalculator
    {
        private readonly Database db;

        public MaterialCalculator(Database database)
        {
            db = database;
        }

        public int CalculateMaterial(int productTypeId, int materialTypeId, int quantity, double param1, double param2)
        {
            var (productCoeff, defectPercent) = db.GetCoefficients(productTypeId, materialTypeId);

            // Проверяем, что данные корректные
            if (!productCoeff.HasValue || !defectPercent.HasValue || quantity <= 0 || param1 <= 0 || param2 <= 0)
                return -1;

            // Расчёт количества материала
            double requiredMaterial = (param1 * param2 * productCoeff.Value) * quantity;
            requiredMaterial *= (1 + defectPercent.Value / 100.0);

            return (int)Math.Ceiling(requiredMaterial);
        }
    }
}
