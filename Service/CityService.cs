using GeoInfo.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;

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
                else { info2 = "Города в разных временных зонах"; }
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
            var _city = CreateCity.CreateCityDto(createCity);
            await DataBaseContext.Cities.AddAsync(_city);
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
            var _city = UpdateCity.UpdateCityDto(updateCity);

            var city = await DataBaseContext.Cities.FirstOrDefaultAsync(c => c.Id == id);

            if (city != null) return;

            city.Name = _city.Name;
            city.AsciiName = _city.AsciiName;
            city.AlternateName = _city.AlternateName;
            city.Latitude = _city.Latitude;
            city.Longitude = _city.Longitude;
            city.FeatureClass = _city.FeatureClass;
            city.FeatureCode = _city.FeatureCode;
            city.CountryCode = _city.CountryCode;
            city.Cc2 = _city.Cc2;
            city.Admin1Code = _city.Admin1Code;
            city.Admin2Code = _city.Admin2Code;
            city.Admin3Code = _city.Admin3Code;
            city.Admin4Code = _city.Admin4Code;
            city.Population = _city.Population;
            city.Elevation = _city.Elevation;
            city.Dem = _city.Dem;
            city.TimeZone = _city.TimeZone;
            city.ModificationDate = _city.ModificationDate;

            await DataBaseContext.SaveChangesAsync();
            return;
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