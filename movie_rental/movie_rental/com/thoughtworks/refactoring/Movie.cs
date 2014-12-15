using System;

namespace com.thoughtworks.refactoring
{

public class Movie {
		public const int CHILDRENS = 2;
		public const int REGULAR = 0;
		public const int NEW_RELEASE = 1;
		private string title;
		private int priceCode;

	public Movie(String title, int priceCode) {
		this.title = title;
		this.priceCode = priceCode;
	}

		public int GetPriceCode() {
		return priceCode;
	}

		public void SetPriceCode(int arg) {
    	priceCode = arg;
	}

		public String GetTitle () {
		return title;
	}
}
}
