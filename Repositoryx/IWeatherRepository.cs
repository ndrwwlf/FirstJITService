using System;
using System.Collections.Generic;
using WeatherService.Dao;
using WeatherService.Db;
using WeatherService.Dto;
using WeatherService.Model;

namespace WeatherService.Services
{
    public interface IWeatherRepository
    {
        List<string> GetDistinctZipCodes();
        bool InsertWeatherData(WeatherData weatherData);
        bool GetWeatherDataExistForZipAndDate(string ZipCode, DateTime rDate);
        List<WeatherData> GetWeatherData(PageParams pageParams);
        List<WeatherData> GetWeatherDataByZipCode(string ZipCode, PageParams pageParams);
        int GetWeatherDataRowCount(string ZipCode);
        int GetWeatherDataRowCountByZip(string ZipCode);
        string GetMostRecentWeatherDataDate();
        List<ReadingsQueryResult> GetReadings(string DateStart);
        List<WeatherData> GetWeatherDataByZipStartAndEndDate(string ZipCode, DateTime DateStart, DateTime DateEnd);
        bool InsertWthExpUsage(int readingId, decimal value);
    }
}
