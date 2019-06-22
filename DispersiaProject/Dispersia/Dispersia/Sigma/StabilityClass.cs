using System;


namespace Dispersia.SigmaCalculator
{
    public class StabilityClass
    {
        public enum IncomeSolarRadiation
        {
               STRONG=1,
               MODERATE=2,
               SLIGHT=3
        }

        public enum CloudCover
        {
            LOW = 1,
            HIGH = 2
        }


        public StabilityClassEnum getStabilityClass(double windSpeed, Boolean isNight, IncomeSolarRadiation solarRadiation, CloudCover cloudCover)
        {
            int StabilityClassIndex = -1;


            //TODO  - Stability Class 0??!??!?!? Should be 1.
            if (windSpeed < 2)
            {
                StabilityClassIndex = 0;
            }
            else if ((windSpeed >= 2) && (windSpeed < 3))
            {
                StabilityClassIndex = 1;
            }
            else if ((windSpeed >= 3) && (windSpeed < 5))
            {
                StabilityClassIndex = 2;
            }
            else if ((windSpeed >= 5) && (windSpeed < 6))
            {
                StabilityClassIndex = 3;
            }
            else if (windSpeed >= 6)
            {
                StabilityClassIndex = 4;
            }


            StabilityClassEnum[] StabilityClasses = null;

            if (isNight)
            {
                StabilityClasses = GetStabilityClassNight(cloudCover);

            }
            else
            {
                StabilityClasses = GetStabilityClassDay(solarRadiation);
            }

            return StabilityClasses[StabilityClassIndex];

        }

        private StabilityClassEnum[] GetStabilityClassDay(IncomeSolarRadiation solarRadiation)
        {

            StabilityClassEnum[] Strong = { StabilityClassEnum.A, StabilityClassEnum.A, StabilityClassEnum.B, StabilityClassEnum.C, StabilityClassEnum.C };
            StabilityClassEnum[] Moderate = { StabilityClassEnum.A, StabilityClassEnum.B, StabilityClassEnum.B, StabilityClassEnum.C, StabilityClassEnum.D };
            StabilityClassEnum[] Slight = { StabilityClassEnum.B, StabilityClassEnum.C, StabilityClassEnum.C, StabilityClassEnum.D, StabilityClassEnum.D };


            switch (solarRadiation)
            {
                case IncomeSolarRadiation.STRONG: return Strong;
                case IncomeSolarRadiation.MODERATE: return Moderate;
                case IncomeSolarRadiation.SLIGHT: return Slight;
            }

            return null; 
        }

        private StabilityClassEnum[] GetStabilityClassNight(CloudCover cloudCover)
        {

            StabilityClassEnum[] High = { StabilityClassEnum.E, StabilityClassEnum.E, StabilityClassEnum.D, StabilityClassEnum.D, StabilityClassEnum.D };
            StabilityClassEnum[] Low = { StabilityClassEnum.F, StabilityClassEnum.F, StabilityClassEnum.E, StabilityClassEnum.D, StabilityClassEnum.D };


            switch (cloudCover)
            {
                case CloudCover.LOW: return Low;
                case CloudCover.HIGH: return High;
            }

            return null;
        }
    }
}
