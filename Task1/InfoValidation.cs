using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Task1
{
    public class InfoValidation
    {
        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public string PhoneNumber { get; private set; }

        public InfoValidation(string first_name, string last_name, string phone_number)
        {
            string phoneNum;
            if (isValidPhone(phone_number, out phoneNum))
            {
                FirstName = nameFormatting(first_name);
                LastName = nameFormatting(last_name);
                PhoneNumber = phoneFormatting(phoneNum);
                Console.WriteLine($"{FirstName} {LastName} {PhoneNumber}");
            }
            else
            {
                Console.WriteLine($"Неверный формат: {phoneNum}");
            }
        }

        public string nameFormatting(string name)
        {
            string new_name = name.Replace(" ", "");
            return new_name.Substring(0, 1).ToUpper() + new_name.Substring(1);
        }

        public string phoneFormatting(string phone)
        {
            return $"+{phone.Substring(0, 2)}({phone.Substring(2, 3)})" +
                $"{phone.Substring(5, 3)}-{phone.Substring(8, 2)}-{phone.Substring(10)}";
        }

        public bool isValidPhone(string phone, out string phoneNum)
        {
            Regex regex = new Regex(@"\D");
            phoneNum = regex.Replace(phone, "");
            if (phoneNum.Length == 11) return true;
            return false;
        }
    }
}
//Валидация и Форматирование Номера Телефона
//Требования:
//1.Входные поля: Имя(FirstName), Фамилия(LastName), Телефон(PhoneNumber).
//2.Форматирование Имени / Фамилии: Удалить пробелы и применить стандартный регистр.
//3. Валидация и Форматирование Телефона:
//    ◦ Из строки телефона удалить все нецифровые символы (скобки, пробелы, дефисы).
//    ◦ Проверить, что итоговая строка содержит ровно 11 цифр (например, с кодом страны).
//    ◦ Если валидация успешна, отформатировать телефон в международном формате: +X(XXX) XXX - XX - XX.
//    ◦ Если валидация неуспешна, вернуть телефон как "Неверный формат".
//4. Вывод: Полное отформатированное имя и результат обработки телефона.
