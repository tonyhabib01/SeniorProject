using GymApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GymApplication.ViewModels
{
	public class DashboardViewModel
	{
		public List<Earning> Earnings { get; set; }
		public List<Earning> MonthlyEarnings { get; set; }
		public List<Earning> YearlyEarnings { get; set; }
		public DashboardViewModel(List<Earning> earning)
		{
			Earnings = earning;
			MonthlyEarnings = MonthlyEarning();
			YearlyEarnings = YearlyEarning();
		}

		private List <Earning> MonthlyEarning()
		{
			return Earnings.Where(e => e.Datetime.Month == DateTime.Now.Month).ToList();
		}

		private List <Earning> YearlyEarning ()
		{
			return Earnings.Where(e => e.Datetime.Year == DateTime.Now.Year).ToList();
		}
		
		public double GetMonthlyProfit()
		{
			double profit = 0;
			foreach(var monthlyEarning in MonthlyEarnings)
			{
				profit += monthlyEarning.Profit;	
			}

			return profit;
		}

		public double GetYearlyProfit()
		{
			double profit = 0;
			foreach (var yearlyEarning in YearlyEarnings)
			{
				profit += yearlyEarning.Profit;
			}

			return profit;
		}
	}
}