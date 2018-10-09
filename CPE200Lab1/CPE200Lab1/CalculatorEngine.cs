using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPE200Lab1
{ 
    public class CalculatorEngine
    {   /// <summary>
    /// 
    /// </summary>
    /// <param name="str"></param>
    /// <returns></returns>
        private bool isNumber(string str)
        {
            double retNum;
            return Double.TryParse(str, out retNum);
        }
        /// <summary>
        /// ตรวจสอบว่ามี operator หรือยัง
        /// </summary>
        /// <param name="str">ส่ง operator ไป</param>
        /// <returns>return ว่ามีoperatorหรือไม่</returns>
        private bool isOperator(string str)
        {
            switch (str)
            {
                case "+":
                case "-":
                case "X":
                case "÷":
                case "%":   //add case %
                    return true;
            }
            return false;
        }
      /// <summary>
      /// สร้างกรณีเฉพาะสำหรับ operatorบางตัวให้รับ input ค่าเดียวไดั
      /// </summary>
      /// <param name="str">ส่ง operator ไป</param>
      /// <returns>return ว่าเป็นoperatorที่ต้องยกเว้นมั้ย(สามารถให้ใช้inputตัวเดียวได้)</returns>
        public bool OnlyOneOperand(string str)  //function use for only one operate ex. 1/2 sqrt(4)
        {   
            if (str == "1/x" || str == "√")
            {
                return true;
            }
            else return false;

        }
        /// <summary>
        /// เป็นการเอาค่าinputมาแยกใส่ในarray
        /// </summary>
        /// <param name="str">ส่งค่าตัววเลข + operator</param>
        /// <returns>ข้อมูลที่ถูกใส่ในarray</returns>
        public string Process(string str)
        {
            string[] parts = str.Split(' ');
            if (parts.Length >= 4)
            {
                if (isNumber(parts[0]) && isOperator(parts[1]) && isNumber(parts[2]) && isOperator(parts[3]))
                {
                    return PercentCalculate(parts[1], parts[0], parts[2], 4);
                }
            }
            try
            {
                return calculate(parts[1], parts[0], parts[2], 4); //try to calculating ถ้ามีตัวเดียวก็จะไม่เป็นตาม condition
            }
            catch
            {
                return "E";
            }
           /* if (isNumber(parts[0]) && isOperator(parts[1]) && isNumber(parts[2]))
            {
                return calculate(parts[1], parts[0], parts[2], 4);
            }
            else if (isNumber(parts[0]) && OnlyOneOperand(parts[1]))
            {
                return unaryCalculate(parts[1], parts[0], 4);
            }

            else
            {
                return "E";
            }*/
           

        }
        /// <summary>
        /// เป็นการคำนวณของ sqrt & 1/x (input เลขตัวเดียว)
        /// </summary>
        /// <param name="operate">ค่าของoperator</param>
        /// <param name="operand">ค่าของตัวเลขที่ถูกinput</param>
        /// <param name="maxOutputSize">ขนาดของoutputที่จะแสดงผล</param>
        /// <returns>ผลลัพธ์จากการคำนวณ</returns>
        public string unaryCalculate(string operate, string operand, int maxOutputSize = 8)
        {
            switch (operate)
            {
                case "√":
                    {
                        double result;
                        string[] parts;
                        int remainLength;

                        result = Math.Sqrt(Convert.ToDouble(operand));
                        // split between integer part and fractional part
                        parts = result.ToString().Split('.');
                        // if integer part length is already break max output, return error
                        if (parts[0].Length > maxOutputSize)
                        {
                            return "E";
                        }
                        // calculate remaining space for fractional part.
                        remainLength = maxOutputSize - parts[0].Length - 1;
                        // trim the fractional part gracefully. =
                        return result.ToString("N" + remainLength).Contains(".") ? result.ToString("N" + remainLength).TrimEnd('0').TrimEnd('.') : result.ToString("N" + remainLength);
                    }
                case "1/x":
                    if (operand != "0")
                    {
                        double result;
                        string[] parts;
                        int remainLength;

                        result = (1.0 / Convert.ToDouble(operand));
                        // split between integer part and fractional part
                        parts = result.ToString().Split('.');
                        // if integer part length is already break max output, return error
                        if (parts[0].Length > maxOutputSize)
                        {
                            return "E";
                        }
                        // calculate remaining space for fractional part.
                        remainLength = maxOutputSize - parts[0].Length - 1;
                        // trim the fractional part gracefully. =
                        return result.ToString("N" + remainLength).Contains(".") ? result.ToString("N" + remainLength).TrimEnd('0').TrimEnd('.') : result.ToString("N" + remainLength);
                    }
                    break;
            }
            return "E";
        }
        /// <summary>
        /// การคำนวณค่าของ input แบบปกติ
        /// </summary>
        /// <param name="operate">ค่าของ operator</param>
        /// <param name="firstOperand">เลขตัวแรกที่เราinput</param>
        /// <param name="secondOperand">เลขตัวที่2ที่เราinput</param>
        /// <param name="maxOutputSize">ขนาดของoutputที่จะแสดงผล</param>
        /// <returns>ผลลัพธ์จากการคำนวณ</returns>
        public string PercentCalculate(string operate, string firstOperand, string secondOperand, int maxOutputSize = 8)    // return case of secondoperand
        {
            switch (operate)
            {
                case "+":
                    return (Convert.ToDouble(firstOperand) + (Convert.ToDouble(firstOperand) * (0.01 * Convert.ToDouble(secondOperand)))).ToString();
                case "-":
                    return (Convert.ToDouble(firstOperand) - (Convert.ToDouble(firstOperand) * (0.01 * Convert.ToDouble(secondOperand)))).ToString();
                case "X":
                    return (Convert.ToDouble(firstOperand) * (Convert.ToDouble(firstOperand) * (0.01 * Convert.ToDouble(secondOperand)))).ToString();
                case "÷":
                    return (Convert.ToDouble(firstOperand) / (Convert.ToDouble(firstOperand) * (0.01 * Convert.ToDouble(secondOperand)))).ToString();
            }
            return "E";
        }
        public string PercentResult(string firstOperand, string secondOperand, int maxOutputSize = 8)     // return result
        {

            return (Convert.ToDouble(firstOperand) * (0.01 * Convert.ToDouble(secondOperand))).ToString();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="operate"></param>
        /// <param name="firstOperand"></param>
        /// <param name="secondOperand"></param>
        /// <param name="maxOutputSize"></param>
        /// <returns></returns>
        public string calculate(string operate, string firstOperand, string secondOperand, int maxOutputSize = 8)
        {
            switch (operate)
            {
                case "+":
                    return (Convert.ToDouble(firstOperand) + Convert.ToDouble(secondOperand)).ToString();
                case "-":
                    return (Convert.ToDouble(firstOperand) - Convert.ToDouble(secondOperand)).ToString();
                case "X":
                    return (Convert.ToDouble(firstOperand) * Convert.ToDouble(secondOperand)).ToString();
                case "÷":
                    // Not allow devide be zero
                    //if (secondOperand != "0")
                    try
                    {
                        if (secondOperand == "0") {
                            throw (new DivideByZeroException());
                        }

                        return (Convert.ToDouble(firstOperand) / Convert.ToDouble(secondOperand)).ToString();
                    }
                    catch(DivideByZeroException ex)
                    {
                        return "E";
                    }
                    {
                        double result;
                        string[] parts;
                        int remainLength;

                        result = (Convert.ToDouble(firstOperand) / Convert.ToDouble(secondOperand));
                        // split between integer part and fractional part
                        parts = result.ToString().Split('.');
                        // if integer part length is already break max output, return error
                        if (parts[0].Length > maxOutputSize)
                        {
                            return "E";
                        }
                        // calculate remaining space for fractional part.
                        remainLength = maxOutputSize - parts[0].Length - 1;
                        // trim the fractional part gracefully. =
                        return result.ToString("N" + remainLength).Contains(".") ? result.ToString("N" + remainLength).TrimEnd('0').TrimEnd('.') : result.ToString("N" + remainLength);//result.ToString("N" + remainLength)
                    }
                    break;
                case "%":
                    //your code here
                    //line 105 - 124

                    break;
            }
            return "E";
        }
    }
}