using GeoInfo.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Xml.Linq;

namespace GeoInfo.Service
{
    public class CityService
    {
        private ApplicationDbContext DataBaseContext;
        public CityService(ApplicationDbContext _context)
        {
            DataBaseContext = _context;
        }

        /// <summary>
        /// Получение города по его идентификатору
        /// </summary>
        /// <param name="id">Идентификатор города</param>
        /// <returns>Модель города</returns>
        public async Task<CityDto> GetCityByIdAsync(long id)
        {
            var city = await DataBaseContext
                .Cities
                .AsNoTracking()
                .FirstOrDefaultAsync(city => city.Id == id);

            return CityDto.CreateCityDto(city);
        }

        /// <summary>
        /// Отображение указанной страницы с городами
        /// </summary>
        /// <param name="page">Номер страницы</param>
        /// <param name="pageSize">Количество городов на странице</param>
        /// <returns>Возврат списка городов с их информацией</returns>
        public async Task<CollectionViewModel<CityDto>> GetPageAsync(int page, int pageSize)
        {
            var source = DataBaseContext.Cities;
            var count = await source.CountAsync();
            var items = await source.Skip((page - 1) * pageSize).Take(pageSize).ToListAsync();

            var dto = items.Select(city => CityDto.CreateCityDto(city));
            return new CollectionViewModel<CityDto>(dto, count);
        }
        /// <summary>
        /// Получение двух городов по названию
        /// </summary>
        /// <param name="name1">Название первого города</param>
        /// <param name="name2">Название второго города</param>
        /// <returns>Информация о городах</returns>
        public async Task<TwoCitiesInfo<CityDto>> GetTwoCitiesAsync(string name1, string name2)
        {
            var cities = await DataBaseContext.Cities
                .Where(x => EF.Functions.ILike(x.Name, $"%{name1}%") ||
                            EF.Functions.ILike(x.Name, $"%{name2}%"))
                .GroupBy(x => x.Name,
                    (s, cities) => cities.OrderByDescending(c => c.Population).First())
                .AsNoTracking()
                .ToListAsync();

            string info1 = "";
            string info2 = "";

            if (cities.Count() == 2)
            {
                if (city1.Latitude) > (city2.Latitude) { info1 = $"Город {city1.Name} находится севернее города {city2.Name}."; }
                else { info1 = $"Город {city2.Name} находится севернее города {city1.Name}."; }

                if (city1.TimeZone == city2.TimeZone) { info2 = "Города в одной временной зоне"; }
                else
                {
                    var _cityDict = new TimeZoneDict();
                    _cityDict.Dict();
                    var timeOfCity1 = _cityDict._timeZones[city1.TimeZone];
                    var timeOfCity2 = _cityDict._timeZones[city2.TimeZone];
                    info2 = $"Города в разных временных зонах. Разность во времени составляет {Math.Abs(timeOfCity2 - timeOfCity1)} час(а).";
                }
            }

            var Info = info1 + " " + info2;

            return new TwoCitiesInfo<CityDto>(cities, Info);
        }

        /// <summary>
        /// Добавление нового города
        /// </summary>
        /// <param name="establishedCity">Модель города</param>
        /// <returns>Идентификатор созданного города</returns>
        public async Task<long> CreateCityAsync(CreateCityDto establishedCity)
        {
            var city = City.Create(establishedCity.Name, establishedCity.AsciiName, establishedCity.AlternateName, establishedCity.Latitude, establishedCity.Longitude, establishedCity.FeatureClass, establishedCity.FeatureCode, establishedCity.CountryCode, establishedCity.Cc2, establishedCity.Population, establishedCity.Elevation, establishedCity.Dem, establishedCity.TimeZone);
            
            await DataBaseContext.Cities.AddAsync(city);
            
            await DataBaseContext.SaveChangesAsync();

            return city.Id;
        }

        /// <summary>
        /// Обновление информации о городе по его идентификатору
        /// </summary>
        /// <param name="id">Идентификатор города</param>
        /// <param name="updateCity">Данные о городе</param>
        public async Task UpdateCityAsync(long id, UpdateCityDto updateCity)
        {

            var city = await DataBaseContext.Cities.FirstOrDefaultAsync(c => c.Id == id);

            if (city != null) return;

            city.Name = updateCity.Name;
            city.AsciiName = updateCity.AsciiName;
            city.AlternateName = updateCity.AlternateName;
            city.Latitude = updateCity.Latitude;
            city.Longitude = updateCity.Longitude;
            city.FeatureClass = updateCity.FeatureClass;
            city.FeatureCode = updateCity.FeatureCode;
            city.CountryCode = updateCity.CountryCode;
            city.Cc2 = updateCity.Cc2;
            city.Population = updateCity.Population;
            city.Elevation = updateCity.Elevation;
            city.Dem = updateCity.Dem;
            city.TimeZone = updateCity.TimeZone;
            city.ModificationDate = DateTime.UtcNow;

            await DataBaseContext.SaveChangesAsync();

        }

        /// <summary>
        /// Удаление города по его идентификатору
        /// </summary>
        /// <param name="id">Идентификатор города</param>
        public async Task DeleteCityAsync(long id)
        {
            var city = await DataBaseContext.Cities.FirstOrDefaultAsync(c => c.Id == id);

            DataBaseContext.Cities.Remove(city);
            await DataBaseContext.SaveChangesAsync();

            return;
        }
    }
}