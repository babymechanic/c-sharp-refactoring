using System;
using System.Globalization;
using System.Collections.Generic;

namespace com.thoughtworks.refactoring
{
	public class DateParser {
		private readonly string dateAndTimeString;
		private static Dictionary<string, TimeZoneInfo> KNOWN_TIME_ZONES = new Dictionary<string, TimeZoneInfo>();

		static DateParser(){
			KNOWN_TIME_ZONES.Add("UTC", TimeZoneInfo.Utc);
    	}

    /**
     * Takes a date in ISO 8601 format and returns a date
     *
     * @param dateAndTimeString - should be in format ISO 8601 format
     *                          examples -
     *                          2012-06-17 is 17th June 2012 - 00:00 in UTC TimeZone
     *                          2012-06-17TZ is 17th June 2012 - 00:00 in UTC TimeZone
     *                          2012-06-17T15:00Z is 17th June 2012 - 15:00 in UTC TimeZone
     */
		public DateParser(string dateAndTimeString) {
        this.dateAndTimeString = dateAndTimeString;
    	}

		public DateTime parse() {
        int year, month, date, hour, minute;

        try {
				string yearString = dateAndTimeString.Substring(0, 4);
				year = int.Parse(yearString);
			} catch (ArgumentOutOfRangeException e) {
            throw new ArgumentException("Year string is less than 4 characters");
        } catch (FormatException e) {
				throw new ArgumentException("Year is not an integer");
        }
        if (year < 2000 || year > 2012)
				throw new ArgumentException("Year cannot be less than 2000 or more than 2012");

        try {
				string monthString = dateAndTimeString.Substring(5, 2);
            	month = int.Parse(monthString);
			} catch (ArgumentOutOfRangeException e) {
            throw new ArgumentException("Month string is less than 2 characters");
			} catch (FormatException e) {
            throw new ArgumentException("Month is not an integer");
        }
        if (month < 1 || month > 12)
            throw new ArgumentException("Month cannot be less than 1 or more than 12");

        try {
				string dateString = dateAndTimeString.Substring(8, 2);
            date = int.Parse(dateString);
			} catch (ArgumentOutOfRangeException e) {
            throw new ArgumentException("Date string is less than 2 characters");
			} catch (FormatException e) {
            throw new ArgumentException("Date is not an integer");
        }
        if (date < 1 || date > 31)
            throw new ArgumentException("Date cannot be less than 1 or more than 31");

			if (dateAndTimeString.Substring(11, 1).Equals("Z")) {
            hour = 0;
            minute = 0;
        } else {
            try {
					string hourString = dateAndTimeString.Substring(11, 2);
                hour = int.Parse(hourString);
				} catch (ArgumentOutOfRangeException e) {
                throw new ArgumentException("Hour string is less than 2 characters");
            } catch (FormatException e) {
                throw new ArgumentException("Hour is not an integer");
            }
            if (hour < 0 || hour > 23)
                throw new ArgumentException("Hour cannot be less than 0 or more than 23");

            try {
					string minuteString = dateAndTimeString.Substring(14, 2);
                minute = int.Parse(minuteString);
				} catch (ArgumentOutOfRangeException e) {
                throw new ArgumentException("Minute string is less than 2 characters");
            } catch (FormatException e) {
                throw new ArgumentException("Minute is not an integer");
            }
            if (minute < 0 || minute > 59)
                throw new ArgumentException("Minute cannot be less than 0 or more than 59");

        }

		var dateTime = new DateTime(year,month, date, hour, minute,0,0,DateTimeKind.Utc);
		return dateTime;
    }
}

}
