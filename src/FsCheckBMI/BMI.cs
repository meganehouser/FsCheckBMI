namespace FsCheckBMI
{
    public class BMI
    {
        /// <summary>
        /// BMIを算出する
        /// </summary>
        public static double Compute(int height, int weight)
        {
            var w = (double)weight;
            var h = (double)height / 100.0;
            return w / (h * h);
        }
    }
}
