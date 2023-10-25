using System;
using System.Collections.Generic;
using System.Linq;

namespace AnarchyInHospital
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Hospital hospital = new Hospital();

            hospital.Work();

            Console.ReadLine();
        }
    }

    class Hospital
    {
        private IEnumerable<Patient> _patients = new List<Patient>();

        public Hospital()
        {
            _patients = new List<Patient>
            {
                new Patient("Кулешов Даниэль Михайлович", "Панкреатит", 45),
                new Patient("Игнатьев Константин Миронович", "Сколиоз", 34),
                new Patient("Столярова Милана Мироновна", "Атерома", 20),
                new Patient("Матвеева Тамара Евгеньевна", "Панкреатит", 19),
                new Patient("Андреева Полина Серафимовна", "Псориаз", 37),
                new Patient("Свиридов Степан Максимович", "Псориаз", 56),
                new Patient("Овсянников Михаил Максимович", "Пародонтит", 67),
                new Patient("Ларин Лев Тимофеевич", "Ихтиоз", 41),
                new Patient("Петров Сергей Георгиевич", "Изжога", 35),
                new Patient("Соловьев Руслан Никитич", "Пародонтит", 26),
            };
        }

        public void Work()
        {
            bool isWorking = true;

            while (isWorking)
            {
                const string ShowNameCommand = "1";
                const string ShowAgeCommand = "2";
                const string ShowDiagnosisCommand = "3";
                const string ExtitCommand = "4";

                Console.WriteLine("Добро пожаловать в больницу.\n");

                Console.WriteLine($"Показать имя пациента: {ShowNameCommand}\n" +
                                  $"Покзаать возраст пациента: {ShowAgeCommand}\n" +
                                  $"Показать диагноз пациента: {ShowDiagnosisCommand}\n" +
                                  $"Выход: {ExtitCommand}");

                switch (Console.ReadLine())
                {
                    case ShowNameCommand:
                        Show(GetSortedPatientNames());
                        break;

                    case ShowAgeCommand:
                        Show(GetSortedPatientsByAge());
                        break;

                    case ShowDiagnosisCommand:
                        FoundPatientWithDisease();
                        break;

                    case ExtitCommand:
                        isWorking = false;
                        break;
                }

                Console.ReadLine();
                Console.Clear();
            }
        }

        private IEnumerable<Patient> GetSortedPatientNames() =>
           _patients = _patients.OrderBy(patient => patient.FullName);

        private IEnumerable<Patient> GetSortedPatientsByAge() =>
             _patients = _patients.OrderBy(patient => patient.Age);

        private void FoundPatientWithDisease()
        {
            Console.Write("Введите диагноз: ");
            string disease = Console.ReadLine();

            IEnumerable<Patient> foundPatient = _patients.Where(patient => patient.Diagnosis.StartsWith(disease));

            foreach (var diagnosis in foundPatient)
            {
                diagnosis.ShowInfo();
            }
        }

        private void Show(IEnumerable<Patient> patients)
        {
            if (_patients.Any())
            {
                foreach (Patient patient in patients)
                {
                    patient.ShowInfo();
                }
            }
        }
    }

    class Patient
    {
        public Patient(string fullnName, string disease, int age)
        {
            FullName = fullnName;
            Diagnosis = disease;
            Age = age;
        }

        public string FullName { get; private set; }
        public string Diagnosis { get; private set; }
        public int Age { get; private set; }

        public void ShowInfo()
        {
            Console.WriteLine($"имя - {FullName} " +
                              $"возраст - {Age}\t" +
                              $"диагноз - {Diagnosis}");
        }
    }
}
