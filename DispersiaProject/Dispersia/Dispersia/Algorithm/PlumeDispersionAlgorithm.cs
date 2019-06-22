using System;
using Dispersia.SigmaCalculator;


namespace Dispersia.Algorithm
{
    public class PlumeDispersionAlgorithm
    {

        //Changed from here
        
        private float ConcentratiePoluantEmisie = 21630000.0f;
        private float DiametrulCosului = 1.4f;
        private float InaltimeaCosului = 76.0f;
        private float TemperaturaAtmosferei = 15.0f;
        private float TemperaturaGazului = 204.0f;
        private float VitezaGazului = 4.032f;
        private float VitezaVantului = 2.0f;
        private Sigma SigmaValue = new Sigma();
        private Boolean IsSolid = false;
        private float [,]Matrix;
        
        public float VitezaDeSedimentare { get; private set; }

        public float Qf      { get; private set; }
        public float F       { get; private set; }
        public float dH      { get; private set; }
        public float dHf     { get; private set; }
        public float x       { get; private set; }
        public float xf      { get; private set; }
        public float S       { get; private set; }
        public float TCritic { get; private set; }
        public float u       { get; private set; }
        public float Ht      { get; private set; }
        public float a       { get; private set; }
        public float Max     { get; private set; }
        public float Min     { get; private set; }

        //public float returnLength { get; private set; }

        public float Height  { get; private set; }
        private int count = 0;

        public TerrainType terrainType { get; private set; }
        public StabilityClassEnum stabilityClass { get; private set; }


        float[] ATM = { 0.10f, 0.15f, 0.20f, 0.25f, 0.25f, 0.30f };
        int atm;//     =    StabilityClassEnum.getValue();

        public PlumeDispersionAlgorithm( TerrainType terrainType,  StabilityClassEnum stabilityClass, int height, int width)
        {
            this.terrainType = terrainType;
            this.stabilityClass = stabilityClass;
            init(terrainType, stabilityClass);
            Matrix = new float[height,width];
            //this.IsSolid = IsSolid;

        }


        private void init(TerrainType terrainType, StabilityClassEnum stabilityClass )
        {

            this.TemperaturaGazului+= (float)273.1499; //transformare in Kelvin
            this.TemperaturaAtmosferei += (float)273.1499; //transformare In Kelvin

            Qf = (float)((Math.PI * Math.Pow(DiametrulCosului, 2.0f)) / (4.0f * VitezaGazului));
            F = (float)(9.8f * VitezaGazului * Math.Pow(DiametrulCosului, 2.0f) * ((float)(TemperaturaGazului - TemperaturaAtmosferei) / (4.0f * TemperaturaGazului)));
            dH = 0.0f;
            dHf = 0.0f;
            x = 0.0f;
            xf = 0.0f;
            S = 0.0f;
            TCritic = 273.14999999999998f;
            u = 0.0f; //viteza vantului m/s
            Ht = 0.0f;
            a = 0.0f;
            Max = float.MinValue;
            Min = float.MaxValue;
            atm = getStabilityClassValue();

        }


        private int getStabilityClassValue()
        {
            switch (stabilityClass)
            {
                case StabilityClassEnum.A: return 1;
                case StabilityClassEnum.B: return 2;
                case StabilityClassEnum.C: return 3;
                case StabilityClassEnum.D: return 4;
                case StabilityClassEnum.E: return 5;
                case StabilityClassEnum.F: return 6;
            }

            return 0;
        }


        private float GetDeltaH(StabilityClassEnum stabilityClass, int distance)
        {

            float retValue = 0.0f;
            float vitezaVant = 0.0f;

            if (this.F >= 55.0f) this.xf = (float)(119f * Math.Pow(this.F, 0.4f));
            else this.xf = (float)(49f * Math.Pow(this.F, 0.625f));

            vitezaVant = VitezaVantului * (float)Math.Pow(InaltimeaCosului / 10.0f, ATM[getStabilityClassValue() - 1]);

            if (getStabilityClassValue() <= 4)
            {


                if (distance >= (int)this.xf)
                    if (this.F >= 55.0f)
                        retValue = (float)(38.7f * Math.Pow(F, 0.60f) * (1.0f / vitezaVant));
                    else
                        retValue = (float)(21.4f * Math.Pow(F, 0.75f) * (1.0f / vitezaVant));
            }
            else
            {

                if (stabilityClass == StabilityClassEnum.E) this.S = (float)0.02053f;
                if (stabilityClass == StabilityClassEnum.F) this.S = (float)0.0351839f;


                if ((1.84 * vitezaVant / Math.Pow(this.S, 0.5D)) >= xf)
                {
                    if (distance >= (int)this.xf)
                        if (this.F >= 55.0)
                            retValue = (float)(38.7f * Math.Pow(F, 0.60f) * (1.0f / vitezaVant));
                        else
                            retValue = (float)(21.4f * Math.Pow(F, 0.75f) * (1.0f / vitezaVant));
                }
                else
                {

                    retValue = (float)(2.4f * Math.Pow(F / vitezaVant * S, 0.333f));
                }

            }

            return retValue;
        }

        public float Concentratia(int x, int y, int z)
        {
            float retValue = 0.0f;
            float sigmaY = SigmaValue.SigmaY(x, stabilityClass, terrainType);
            float sigmaZ = SigmaValue.SigmaZ(x, stabilityClass, terrainType);

            
            float inaltime = GetDeltaH(stabilityClass, x);
            /*
            if (inaltime <= 0.0f)
            {
                Console.WriteLine("I'm here");
                inaltime = riseOfBentoverPlume(stabilityClass, x);
            }
            */
            inaltime += InaltimeaCosului;

            float vitezaVant = VitezaVantului * (float)Math.Pow(inaltime / 10.0f, ATM[getStabilityClassValue() - 1]);
            float eq1 = (float)(ConcentratiePoluantEmisie / (Math.PI * vitezaVant * sigmaY * sigmaZ));
            float eq2 = (float)(1.0f / Math.Exp(0.5f * Math.Pow(y / sigmaY, 2.0f)));
            float eq3 = (float)(1.0f / Math.Exp(0.5f * Math.Pow(inaltime / sigmaZ, 2.0f)));
            float eq_solid = (float)Math.Exp(-(float)Math.Pow(z - (Height - (VitezaDeSedimentare * x) / VitezaVantului), (float)2.0f) / (2.0f * sigmaZ * sigmaZ));


            if (IsSolid)
            {

                retValue = eq1 * eq_solid;

            }
            else
            {
                retValue = eq1 * eq2 * eq3;

                if (Double.IsNaN(retValue) ||  Double.IsNegativeInfinity(retValue) || Double.IsPositiveInfinity(retValue))
                {
                    retValue = 0.0f;
                    Console.WriteLine("X:" + x + " Y:" + y + "Z:" + z);
                }
            }


            if (Double.IsNaN(retValue) || Double.IsNegativeInfinity(retValue) || Double.IsPositiveInfinity(retValue))
            {
                retValue = 0.0f;
                Console.WriteLine("X:" + x + " Y:" + y + "Z:" + z);
            }

            if (retValue != 0.0f)
            {

                if (retValue.CompareTo(Max) > 0) Max = retValue;
                if (retValue.CompareTo(Min) < 0) Min = retValue;

            }
            /* - Bug
            else

            if (retValue.CompareTo(Math.Pow(10.0f, -20.0f)) < 0)
            {
                retValue = (float)0.0f;

            }*/

            return retValue;

        }

    }
}
