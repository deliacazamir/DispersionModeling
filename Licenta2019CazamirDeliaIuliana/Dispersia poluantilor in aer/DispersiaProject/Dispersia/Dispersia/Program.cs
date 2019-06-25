using System;
using Dispersia.SigmaCalculator;
using Dispersia.Algorithm;

namespace Dispersia
{
    class Program
    {
        static void Main(string[] args)
        {
            Sigma sigma = new Sigma();

            // float[] sigmaY = sigma.sigmaY_Range(0, 10000, StabilityClassEnum.A, TerrainType.URBAN);
            //Console.WriteLine("Count:" + sigmaY.Length);

            PlumeDispersionAlgorithm plume = new PlumeDispersionAlgorithm(TerrainType.RURAL, StabilityClassEnum.A, 2000, 2000);

            string html = "";
            try
            {
                html  = System.IO.File.ReadAllText(@"heatmap.html");
              //  Console.WriteLine(html);
                //System.IO.File.Delete(@"output.txt");
            }
            catch (Exception e) { };

            try
            {
                string line = "";

                for (int i = 0; i < 2000; i += 10)
                {
                    for (int j = 0; j < 2000; j += 10)
                    {
                        double value = (plume.Concentratia(i, j, 0));
                        if (!value.Equals(0.0) && value.CompareTo(0.001) > 0)
                       line += "{ x:" + (i) + ", y:" + (j) + ", size: 100, intensity: " + value.ToString() + "},\n";
               //       Console.WriteLine(value);
                    }

                }
              string first = html.Insert(html.IndexOf("<!--REPLACE_THIS!-->"), line);
                System.IO.File.WriteAllText(@"output.txt", line);
                System.IO.File.WriteAllText(@"heatmap_output.html", first);
            
            } catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }

        }
    }
}
