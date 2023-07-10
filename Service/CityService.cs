using GeoInfo.Models;
using Microsoft.EntityFrameworkCore;

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
        public async Task<CityDto> GetCityByIdAsync(long id, CancellationToken cancellationToken)
        {
            var city = await DataBaseContext
                .Cities
                .AsNoTracking()
                .FirstOrDefaultAsync(city => city.Id == id, cancellationToken);

            if(city == null)
            {
                throw new NotFoundException("Город не найден");
            }

            return CityDto.CreateCityDto(city);
        }

        /// <summary>
        /// Отображение указанной страницы с городами
        /// </summary>
        /// <param name="page">Номер страницы</param>
        /// <param name="pageSize">Количество городов на странице</param>
        /// <returns>Возврат списка городов с их информацией</returns>
        public async Task<CollectionViewModel<CityDto>> GetPageAsync(int page, int pageSize, CancellationToken cancellationToken)
        {
            var source = DataBaseContext.Cities;

            var count = await source.CountAsync(cancellationToken);

            var items = await source.AsNoTracking().Skip((page - 1) * pageSize).Take(pageSize).ToListAsync(cancellationToken);

            var dto = items.Select(city => CityDto.CreateCityDto(city));

            return new CollectionViewModel<CityDto>(dto, count);
        }

        /// <summary>
        /// Получение двух городов по названию
        /// </summary>
        /// <param name="name1">Название первого города</param>
        /// <param name="name2">Название второго города</param>
        /// <returns>Информация о городах</returns>
        public async Task<TwoCitiesInfoDto> GetTwoCitiesAsync(string name1, string name2, CancellationToken cancellationToken)
        {
            var cities = await DataBaseContext.Cities
                .Where(x => EF.Functions.ILike(x.Name, $"{name1}") ||
                            EF.Functions.ILike(x.Name, $"{name2}"))
                .GroupBy(x => x.Name,
                    (s, cities) => cities.OrderByDescending(c => c.Population).First())
                .AsNoTracking()
                .ToListAsync(cancellationToken);

            var info = GetInfoAboutLatitudeTimeDifference(cities);

            return new TwoCitiesInfoDto(cities, info);
        }

        /// <summary>
        /// Добавление нового города
        /// </summary>
        /// <param name="createCityDto">Модель города</param>
        /// <returns>Идентификатор созданного города</returns>
        public async Task<long> CreateCityAsync(CreateCityDto createCityDto, CancellationToken cancellationToken)
        {
            var city = City.Create(createCityDto.Name,
                                   createCityDto.AsciiName,
                                   createCityDto.AlternateName,
                                   createCityDto.Latitude,
                                   createCityDto.Longitude,
                                   createCityDto.FeatureClass,
                                   createCityDto.FeatureCode,
                                   createCityDto.CountryCode,
                                   createCityDto.Cc2,
                                   createCityDto.Population,
                                   createCityDto.Elevation,
                                   createCityDto.Dem,
                                   createCityDto.TimeZone);

            await DataBaseContext.Cities.AddAsync(city, cancellationToken);

            await DataBaseContext.SaveChangesAsync(cancellationToken);

            return city.Id;
        }

        /// <summary>
        /// Обновление информации о городе по его идентификатору
        /// </summary>
        /// <param name="id">Идентификатор города</param>
        /// <param name="updateCityDto">Данные о городе</param>
        public async Task UpdateCityAsync(long id, UpdateCityDto updateCityDto, CancellationToken cancellationToken)
        {
            var city = await DataBaseContext.Cities.FirstOrDefaultAsync(c => c.Id == id, cancellationToken);

            if (city == null)
            {
                throw new NotFoundException("Город не найден");
            }

            city.Name = updateCityDto.Name;
            city.AsciiName = updateCityDto.AsciiName;
            city.AlternateName = updateCityDto.AlternateName;
            city.Latitude = updateCityDto.Latitude;
            city.Longitude = updateCityDto.Longitude;
            city.FeatureClass = updateCityDto.FeatureClass;
            city.FeatureCode = updateCityDto.FeatureCode;
            city.CountryCode = updateCityDto.CountryCode;
            city.Cc2 = updateCityDto.Cc2;
            city.Population = updateCityDto.Population;
            city.Elevation = updateCityDto.Elevation;
            city.Dem = updateCityDto.Dem;
            city.TimeZone = updateCityDto.TimeZone;
            city.ModificationDate = DateTime.UtcNow;

            await DataBaseContext.SaveChangesAsync(cancellationToken);
        }

        /// <summary>
        /// Удаление города по его идентификатору
        /// </summary>
        /// <param name="id">Идентификатор города</param>
        public async Task DeleteCityAsync(long id, CancellationToken cancellationToken)
        {
            var city = await DataBaseContext.Cities.FirstOrDefaultAsync(c => c.Id == id, cancellationToken);

            if (city == null)
            {
                throw new NotFoundException("Город не найден");
            }

            DataBaseContext.Cities.Remove(city);

            await DataBaseContext.SaveChangesAsync(cancellationToken);
        }

        private string GetInfoAboutLatitudeTimeDifference(List<City> cities)
        {
            string info = string.Empty;

            (string latitude, string Time) latitudeAndTime = (string.Empty, string.Empty);

            if (cities.Count == 1) return info = "Второй город не найден";

            if (cities.Count == 2)
            {
                var latitudeDifferenceTemplate = "Город {0} находится севернее города {1}.";

                latitudeAndTime.latitude = cities[0].Latitude > cities[1].Latitude 
                    ? string.Format(latitudeDifferenceTemplate, cities[0].Name, cities[1].Name) 
                    : string.Format(latitudeDifferenceTemplate, cities[1].Name, cities[0].Name);

                latitudeAndTime.latitude = cities[0].TimeZone == cities[1].TimeZone 
                    ? "Города в одной временной зоне"
                    : $"Города в разных временных зонах. Разность во времени составляет {CalculateTimeDifference(cities[1].TimeZone, cities[0].TimeZone)} час(а).";

                info = latitudeAndTime.latitude + " " + latitudeAndTime.Time;
            }

            return info;
        }

        int CalculateTimeDifference(string city1, string city2)
        {
            return Math.Abs(TimeZonesToDigitalConverter.Convert(city1) -
                    TimeZonesToDigitalConverter.Convert(city2));
        }
    }
}