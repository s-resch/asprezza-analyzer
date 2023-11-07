using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ScottPlot.Plottable;

namespace AsprezzaAnalyzer
{
    /// <summary>
    /// Manage ScottPlot settings and render plot
    /// </summary>
    class ScottPlotService
    {
        /// <summary>
        /// Render plot for given data using information from https://scottplot.net/
        /// </summary>
        /// <param name="formPlot">Plot to be used</param>
        /// <param name="line">Signal plot to be used</param>
        /// <param name="dataPoints">Data points to plot</param>
        /// <param name="lables">Lables to show for data points</param>
        /// <param name="title">Title for plot</param>
        /// <returns></returns>
        public static SignalPlot PlotData(ScottPlot.FormsPlot formPlot, SignalPlot line, double[] dataPoints, string[] lables, string title)
        {
            if (dataPoints.Length > 0)
            {
                if (line == null)
                {
                    line = formPlot.Plot.AddSignal(dataPoints);
                }
                else
                {
                    line.Ys = dataPoints;
                }
                //SignalPlot signal = formPlot.Plot.AddSignal(dataPoints, 1);
                formPlot.Plot.Title(title);

                formPlot.Plot.YAxis.LockLimits(false);
                formPlot.Plot.SetAxisLimitsY(0, dataPoints.Max() + 1);
                formPlot.Plot.YAxis.LockLimits(true);
                formPlot.Plot.SetAxisLimitsX(0, dataPoints.Length + 1);
                line.MaxRenderIndex = dataPoints.Length - 1;
                line.LineStyle = ScottPlot.LineStyle.Solid;
                line.LineWidth = 1.75;
                line.Color = System.Drawing.Color.Blue;
                formPlot.Render();
            }
                return line;            
        }
    }
}
