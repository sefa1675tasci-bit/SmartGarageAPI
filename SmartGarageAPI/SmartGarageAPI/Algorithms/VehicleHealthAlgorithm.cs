namespace SmartGarageAPI.Algorithms
{
    public static class VehicleHealthAlgorithm
    {
        public static int CalculateHealthScore(
            int rpm,
            int temperature,
            int speed,
            int fuelLevel)
        {
            int score = 100;

            if (rpm > 5000)
                score -= 25;

            if (temperature > 100)
                score -= 30;

            if (speed > 160)
                score -= 20;

            if (fuelLevel < 15)
                score -= 25;

            if (score < 0)
                score = 0;

            return score;
        }
    }
}