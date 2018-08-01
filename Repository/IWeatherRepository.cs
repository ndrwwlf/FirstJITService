using System;
using System.Collections.Generic;
using JITWeatherService.Dao;
using JITWeatherService.Repository;
using JITWeatherService.Model;

namespace JITWeatherService.Repository
{
    public interface IWeatherRepository
    {
        List<string> GetDistinctZipCodes();
        bool InsertWeatherData(WeatherData weatherData);
        bool GetWeatherDataExistForZipAndDate(string ZipCode, DateTime rDate);
        int GetWeatherDataRowCount();
        int GetWeatherDataRowCountByZip(string ZipCode);
        string GetMostRecentWeatherDataDate();
        List<ReadingsQueryResult> GetReadings(string DateStart);
        int GetExpectedWthExpUsageRowCount(string DateStart);
        int GetActualWthExpUsageRowCount();
        List<WeatherData> GetWeatherDataByZipStartAndEndDate(string ZipCode, DateTime DateStart, DateTime DateEnd);
        bool InsertWthExpUsage(int readingId, decimal value);
    }
}
