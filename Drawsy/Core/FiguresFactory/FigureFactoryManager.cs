using Drawsy.Core.Figures;
using System.Collections.Generic;

namespace Drawsy.Core.FiguresFactory
{
    /// <summary>
    /// Предоставляет доступ к фабрикам фигур  
    /// </summary>
    internal static class FigureFactoryManager
    {
        /// <summary>
        /// Словарь фабрик фигур
        /// </summary>
        private static Dictionary<FiguresEnum, FigureFactory> _factories = new Dictionary<FiguresEnum, FigureFactory>(){
            { FiguresEnum.Rectangle, new RectangleFactory() },
            { FiguresEnum.Ellipse, new EllipseFactory() }
        };

        /// <summary>
        /// Возвращает нужную фабрику
        /// </summary>
        /// <param name="figure">Тип необходимой фабрики</param>
        /// <returns>Фабрика фигур указаного типа</returns>
        public static FigureFactory GetFactory(FiguresEnum figure)
        {
            return _factories[figure];
        }
    }
}
