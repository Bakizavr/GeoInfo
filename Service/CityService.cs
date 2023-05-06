using GeoInfo.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Diagnostics;
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
            var city1 = await DataBaseContext
                .Cities
                .AsNoTracking()
                .Where(city => city.Name == name1)
                .OrderByDescending(city => city.Population)
                .FirstOrDefaultAsync();

            var city2 = await DataBaseContext
                .Cities
                .AsNoTracking()
                .Where(city => city.Name == name2)
                .OrderByDescending(city => city.Population)
                .FirstOrDefaultAsync();

            var cities = new List<City> { city1, city2 };

            var _cities = cities.Where(x => x != null).Select(city => CityDto.CreateCityDto(city)).ToList();

            string info1 = "";
            string info2 = "";

            if (_cities.Count() == 2)
            {
                if (Convert.ToDouble(city1.Latitude) > Convert.ToDouble(city2.Latitude)) { info1 = $"Город {city1.Name} находится севернее города {city2.Name}."; }
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

            return new TwoCitiesInfo<CityDto>(_cities, Info);
        }

        /// <summary>
        /// Добавление нового города
        /// </summary>
        /// <param name="createCity">Модель города</param>
        /// <returns>Идентификатор созданного города</returns>
        public async Task<long> CreateCityAsync(CreateCity createCity)
        {
            var city = City.Create(createCity.Id, createCity.Name, createCity.AsciiName, createCity.AlternateName, createCity.Latitude, createCity.Longitude, createCity.FeatureClass, createCity.FeatureCode, createCity.CountryCode, createCity.Cc2, createCity.Admin1Code, createCity.Admin2Code, createCity.Admin3Code, createCity.Admin4Code, createCity.Population, createCity.Elevation, createCity.Dem, createCity.TimeZone, createCity.ModificationDate);
            
            await DataBaseContext.Cities.AddAsync(city);
            
            await DataBaseContext.SaveChangesAsync();

            return createCity.Id;
        }

        /// <summary>
        /// Обновление информации о городе по его идентификатору
        /// </summary>
        /// <param name="id">Идентификатор города</param>
        /// <param name="updateCity">Данные о городе</param>
        public async Task UpdateCityAsync(long id, UpdateCity updateCity)
        {

            var city = await DataBaseContext.Cities.FirstOrDefaultAsync(c => c.Id == id);

            if (city != null) return;

            city.Name = updateCity.Name;
            city.AsciiName = updateCity.AsciiName;
            city.AlternateName = updateCity.AlternateName;
            city.Latitude = updateCity.Latitude;
            city.Longitude = updateCity.Longitude;

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