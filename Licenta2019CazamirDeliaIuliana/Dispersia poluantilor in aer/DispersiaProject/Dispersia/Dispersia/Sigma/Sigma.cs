using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dispersia.SigmaCalculator
{
    public enum StabilityClassEnum
    {
        A = 1, B = 2, C = 3 , D = 4, E = 5 , F = 6 
    }

    public enum TerrainType
    {
        URBAN = 0,  RURAL=1
    }

    public class Sigma
    {
        public Boolean FLOTABILITY_EFFECT = false;
        public float dH = 0.0f;
        public int MIN_X = 1;
        public int MAX_X = 100000;// Measured in m[meter]

        private float L = 0.0f;
        private float M = 0.0f;
        private float N = 0.0f;

        public float SigmaY(int meter, StabilityClassEnum stabilityClass, TerrainType terrain)
        {

            float retValue = 0.0f;

            if (terrain == TerrainType.URBAN)
            {
                /**URBAN**/
                switch (stabilityClass)
                {

                    case StabilityClassEnum.A:
                        retValue = this.SigmaY_Urban_A(meter);
                        break;

                    //A=B
                    case StabilityClassEnum.B:
                        retValue = this.SigmaY_Urban_B(meter);
                        break;

                    //C
                    case StabilityClassEnum.C:
                        retValue = this.SigmaY_Urban_C(meter);
                        break;

                    //D
                    case StabilityClassEnum.D:
                        retValue = this.SigmaY_Urban_D(meter);
                        break;

                    //E=F
                    case StabilityClassEnum.E:
                        retValue = this.SigmaY_Urban_E(meter);
                        break;

                    //F=E
                    case StabilityClassEnum.F:
                        retValue = this.SigmaY_Urban_F(meter);
                        break;
                }

            }
            else
            {

                /**RURAL**/
                switch (stabilityClass)
                {
                    //A
                    case StabilityClassEnum.A:
                        retValue = this.SigmaY_Rural_A(meter);
                        break;

                    //B
                    case StabilityClassEnum.B:
                        retValue = this.SigmaY_Rural_B(meter);
                        break;

                    //C
                    case StabilityClassEnum.C:
                        retValue = this.SigmaY_Rural_C(meter);
                        break;

                    //D
                    case StabilityClassEnum.D:
                        retValue = this.SigmaY_Rural_D(meter);
                        break;

                    //E
                    case StabilityClassEnum.E:
                        retValue = this.SigmaY_Rural_E(meter);
                        break;

                    //F
                    case StabilityClassEnum.F:
                        retValue = this.SigmaY_Rural_F(meter);
                        break;
                }
            }



            //Efectul de flotabilitate;
            if (this.FLOTABILITY_EFFECT)
            {

                retValue += (float)(dH / 3.5);
            }

            return retValue;
        }

        public float SigmaZ(int meter, StabilityClassEnum stabilityClass, TerrainType terrain)
        {

            float retValue = 0.0f;

            if (terrain == TerrainType.URBAN)
            {

                /**URBAN**/
                switch (stabilityClass)
                {

                    case StabilityClassEnum.A:

                        retValue = this.SigmaZ_Urban_A(meter);
                        break;

                    //A=B
                    case StabilityClassEnum.B:

                        retValue = this.SigmaZ_Urban_B(meter);
                        break;

                    //C
                    case StabilityClassEnum.C:

                        retValue = this.SigmaZ_Urban_C(meter);
                        break;

                    //D
                    case StabilityClassEnum.D:

                        retValue = this.SigmaZ_Urban_D(meter);
                        break;

                    //E=F
                    case StabilityClassEnum.E:
                        retValue = this.SigmaZ_Urban_E(meter);
                        break;

                    //F=E
                    case StabilityClassEnum.F:

                        retValue = this.SigmaZ_Urban_F(meter);
                        break;
                }

            }
            else
            {

                /**RURAL**/
                switch (stabilityClass)
                {
                    //A
                    case StabilityClassEnum.A:

                        retValue = this.SigmaZ_Rural_A(meter);
                        break;

                    //B
                    case StabilityClassEnum.B:

                        retValue = this.SigmaZ_Rural_B(meter);
                        break;

                    //C
                    case StabilityClassEnum.C:

                        retValue = this.SigmaZ_Rural_C(meter);
                        break;

                    //D
                    case StabilityClassEnum.D:

                        retValue = this.SigmaZ_Rural_D(meter);
                        break;

                    //E
                    case StabilityClassEnum.E:

                        retValue = this.SigmaZ_Rural_E(meter);
                        break;

                    //F
                    case StabilityClassEnum.F:

                        retValue = this.SigmaZ_Rural_F(meter);
                        break;
                }
            }

            if (this.FLOTABILITY_EFFECT)
            {

                retValue += (float)dH / 3.5f;
            }

            return retValue;
        }

        public float[] SigmaY_Range(int initialValue, int finalValue, StabilityClassEnum stabilityClass, TerrainType terrain)
        {

            float[] retValue = new float[finalValue - initialValue + 2];

            for (int i = initialValue; i < finalValue + 1; i++)
            {
                retValue[i - initialValue + 1] = SigmaY(i, stabilityClass, terrain);
            }

            return retValue;
        }

        public float[] SigmaZ_Range(int initialValue, int finalValue, StabilityClassEnum stabilityClass, TerrainType terrain)
        {

            float[] retValue = new float[finalValue - initialValue + 2];

            for (int i = initialValue; i < finalValue + 1; i++)
            {
                retValue[i - initialValue + 1] = SigmaZ(i, stabilityClass, terrain);
            }

            return retValue;
        }

        //Sigma Y, URBAN 

        //Y
        private float SigmaY_Urban_A(int x)
        {
            changeLMN(4);
            return (x > 0) ? SigmaValue(x, L, M, N) : 1.0f;
        }
        private float SigmaY_Urban_B(int x)
        {

            return SigmaY_Urban_A(x);
        }
        private float SigmaY_Urban_C(int x)
        {

            changeLMN(5);
            return (x > 0) ? SigmaValue(x, L, M, N) : 1.0f;
        }
        private float SigmaY_Urban_D(int x)
        {

            changeLMN(6);
            return (x > 0) ? SigmaValue(x, L, M, N) : 1.0f;
        }
        private float SigmaY_Urban_E(int x)
        {

            changeLMN(7);
            return (x > 0) ? SigmaValue(x, L, M, N) : 1.0f;
        }
        private float SigmaY_Urban_F(int x)
        {

            return SigmaY_Urban_E(x);
        }
        //Z
        private float SigmaZ_Urban_A(int x)
        {

            changeLMN(0);
            return (x > 0) ? SigmaValue(x, L, M, N) : 1.0f;
        }
        private float SigmaZ_Urban_B(int x)
        {

            return SigmaZ_Urban_A(x);
        }
        private float SigmaZ_Urban_C(int x)
        {

            changeLMN(1);
            return (x > 0) ? SigmaValue(x, L, M, N) : 1.0f;
        }
        private float SigmaZ_Urban_D(int x)
        {

            changeLMN(2);
            return (x > 0) ? SigmaValue(x, L, M, N) : 1.0f;
        }
        private float SigmaZ_Urban_E(int x)
        {

            changeLMN(3);
            return (x > 0) ? SigmaValue(x, L, M, N) : 1.0f;
        }
        private float SigmaZ_Urban_F(int x)
        {
            return SigmaZ_Urban_E(x);
        }


        //Sigma Y, RURAL
        //Y
        private float SigmaY_Rural_A(int x)
        {

            changeIJK(6);
            return (x > 0) ? SigmaRural(x, L, M, N) : 1.0f;
        }
        private float SigmaY_Rural_B(int x)
        {

            changeIJK(7);
            return (x > 0) ? SigmaRural(x, L, M, N) : 1.0f;
        }
        private float SigmaY_Rural_C(int x)
        {

            changeIJK(8);
            return (x > 0) ? SigmaRural(x, L, M, N) : 1.0f;
        }
        private float SigmaY_Rural_D(int x)
        {

            changeIJK(9);
            return (x > 0) ? SigmaRural(x, L, M, N) : 1.0f;
        }
        private float SigmaY_Rural_E(int x)
        {

            changeIJK(10);
            return (x > 0) ? SigmaRural(x, L, M, N) : 1.0f;
        }
        private float SigmaY_Rural_F(int x)
        {

            changeIJK(11);
            return (x > 0) ? SigmaRural(x, L, M, N) : 1.0f;
        }
        //Z
        private float SigmaZ_Rural_A(int x)
        {

            changeIJK(0);
            return (x > 0) ? SigmaRural(x, L, M, N) : 1.0f;
        }
        private float SigmaZ_Rural_B(int x)
        {

            changeIJK(1);
            return (x > 0) ? SigmaRural(x, L, M, N) : 1.0f;
        }
        private float SigmaZ_Rural_C(int x)
        {

            changeIJK(2);
            return (x > 0) ? SigmaRural(x, L, M, N) : 1.0f;
        }
        private float SigmaZ_Rural_D(int x)
        {

            changeIJK(3);
            return (x > 0) ? SigmaRural(x, L, M, N) : 1.0f;
        }
        private float SigmaZ_Rural_E(int x)
        {

            changeIJK(4);
            return (x > 0) ? SigmaRural(x, L, M, N) : 1.0f;
        }
        private float SigmaZ_Rural_F(int x)
        {

            changeIJK(5);
            return (x > 0) ? SigmaRural(x, L, M, N) : 1.0f;
        }

        //Sigma
        private float SigmaValue(float x, float L, float M, float N)
        {


            float X = (float)x / 1000; //Km

            return (float)((L * X) * Math.Pow((1.0f + M * X), N));
        }

        private float SigmaRural(float x, float L, float M, float N)
        {

            float X = (float)x / 1000; //Km

            return (float)Math.Pow(Math.E, L + M * Math.Log(X) + N * Math.Log(X) * Math.Log(X));
        }

        private void changeLMN(int index)
        {
            /**                  zAB   zC    zD      zEF    yAB      yC     yD      yEF      **/
            float[] l_array = { 240f, 200f, 140f, 80f, 320f, 220f, 160f, 110f };
            float[] m_array = { 1.0f, 0.00f, 0.30f, 1.50f, 0.40f, 0.40f, 0.40f, 0.40f };
            float[] n_array = { 0.50f, 0.00f, -0.50f, -0.50f, -0.50f, -0.50f, -0.50f, -0.50f };

            this.L = l_array[index];
            this.M = m_array[index];
            this.N = n_array[index];
        }

        private void changeIJK(int index)
        {
            /**                    zA      zB       zC      zD        zE      zF       yA       yB       yC       yD        yE       yF      **/
            float[] i_array = { 6.0350f, 4.6940f, 4.1100f, 3.4140f, 3.0570f, 2.6210f, 5.3570f, 5.0580f, 4.6510f, 4.2300f, 3.9220f, 3.5330f };
            float[] j_array = { 2.1097f, 1.0629f, 0.9201f, 0.7371f, 0.6794f, 0.6564f, 0.8828f, 0.9024f, 0.9181f, 0.9222f, 0.9222f, 0.9191f };
            float[] k_array = { 0.2770f, 0.0136f, -0.0020f, -0.0316f, -0.0450f, -0.0540f, -0.0076f, -0.0096f, -0.0076f, -0.0087f, -0.0064f, -0.0070f };

            this.L = i_array[index];
            this.M = j_array[index];
            this.N = k_array[index];
        }



        public int getMIN_X()
        {
            return MIN_X;
        }

        public void setMIN_X(int MIN_X)
        {
            this.MIN_X = MIN_X;
        }

        public int getMAX_X()
        {
            return MAX_X;
        }

        public void setMAX_X(int MAX_X)
        {
            this.MAX_X = MAX_X;
        }

        public Boolean isFLOTABILITY_EFFECT()
        {
            return FLOTABILITY_EFFECT;
        }

        public void setFLOTABILITY_EFFECT(Boolean FLOTABILITY_EFFECT)
        {
            this.FLOTABILITY_EFFECT = FLOTABILITY_EFFECT;
        }

        public float getdH()
        {
            return dH;
        }

        public void setdH(float dH)
        {
            this.dH = dH;
        }


    }
}
