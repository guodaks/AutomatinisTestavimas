using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace AutomatinisTestavimas
{
    public class Demo
    {
        //1 skaidre 14 psl

        [Test]
        public static void TestIf4IsEven()
        {
            int leftOver = 4 % 2;
            Assert.AreEqual(0, leftOver, "4 is not even"); //paskutinis - zinute, jei neatitinka salyga/salyga neteisinga.
        }

        [Test]
        public static void TestNowIs19()
        {
            DateTime CurrentTime = DateTime.Now; //suzinom kokia dabar yra valanda
            Assert.IsTrue(CurrentTime.Hour.Equals(19), "Dabar ne 19 valanda");
        }

        [Test]
        public static void TestIf995DividesBy3()
        {
            int leftOver1 = 995 % 3;
            Assert.AreEqual(0, leftOver1, "995 nesidalina is 3");

        }

        [Test]
        public static void TestIfTodayIsMonday()
        {
            DateTime CurrentWeekDay = DateTime.Today; //suranda kokia diena yra siandien
            Assert.IsTrue(CurrentWeekDay.DayOfWeek.Equals(DayOfWeek.Monday), "Siandien ne pirmadienis");
            // patikrina ar siandien pirmadienis, jei ne - testas neigiamas ir isveda zinute
            //Assert.AreEqual(19, CurrentWeekDay.DayOfWeek, "Siandien ne pirmadienis");
        }

        [Test]
        public static void TestWaitFor5Second()
        {
            Thread.Sleep(5000); //milisekundes skliaustuose
        }


    }
}
