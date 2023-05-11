using GeoInfo.Models;
using GeoInfo.Service;
using Microsoft.AspNetCore.Mvc;

namespace GeoInfo.Controllers;
[Route("api/v1/[controller]")]
[ApiController]
public class CitiesController : ControllerBase
{
    private readonly CityService _cityService;

    public CitiesController(CityService cityService)
    {
        _cityService = cityService;
    }

    /// <summary>
    /// Получение города по его идентификатору
    /// </summary>
    /// <param name="id">Идентификатор города</param>
    /// <returns>Модель города</returns>
    [HttpGet("{id:long}")]
    [ProducesResponseType(typeof(City), 200)]
    [ProducesResponseType(typeof(string), 404)]
    [ProducesResponseType(500)]
    public async Task<ActionResult<CityDto>> GetCityById(long id)
    {
        var city = await _cityService.GetCityByIdAsync(id);

        if (city == null) return NotFound("Город не найден");

        return Ok(city);
    }

    /// <summary>
    /// Отображение указанной страницы с городами
    /// </summary>
    /// <param name="page">Номер страницы</param>
    /// <param name="pageSize">Количество городов на странице</param>
    /// <returns>Возврат списка городов с их информацией</returns>
    [HttpGet("{page:int}/{pageSize:int}")]
    [ProducesResponseType(typeof(IEnumerable<City>), 200)]
    [ProducesResponseType(typeof(string), 400)]
    [ProducesResponseType(typeof(string), 404)]
    [ProducesResponseType(500)]
    public async Task<ActionResult<CollectionViewModel<CityDto>>> GetPageIndex(int page, int pageSize)
    {
        var dto = await _cityService.GetPageAsync(page, pageSize);

        return Ok(dto);
    }

    /// <summary>
    /// Получение двух городов по названию
    /// </summary>
    /// <param name="name1">Название первого города</param>
    /// <param name="name2">Название второго города</param>
    /// <returns>Информация о городах</returns>
    [HttpGet("{name1}/{name2}")]
    [ProducesResponseType(typeof(IEnumerable<City>), 200)]
    [ProducesResponseType(typeof(string), 400)]
    [ProducesResponseType(typeof(string), 404)]
    [ProducesResponseType(500)]
    public async Task<ActionResult<IEnumerable<CityDto>>> GetTwoCities(string name1, string name2)
    {
        var cities = await _cityService.GetTwoCitiesAsync(name1, name2);

        if (cities == null) return NotFound("Города не найдены");

        return Ok(cities);
    }

    /// <summary>
    /// Добавление нового города
    /// </summary>
    /// <param name="createCity">Модель города</param>
    /// <returns>Идентификатор созданного города</returns>
    [HttpPost]
    [ProducesResponseType(typeof(long), 200)]
    [ProducesResponseType(500)]
    public async Task<ActionResult<long>> CreateCity(CreateCityDto createCity)
    {
        if (createCity.Id != 0)
        {
            return BadRequest("Id не должен быть заполнен");
        }
        var cityId = await _cityService.CreateCityAsync(createCity);
        return Ok(cityId);
    }

    /// <summary>
    /// Обновление информации о городе по его идентификатору
    /// </summary>
    /// <param name="id">Идентификатор города</param>
    /// <param name="updateCity">Данные о городе</param>
    [HttpPut("{id}")]
    [ProducesResponseType(200)]
    [ProducesResponseType(typeof(string), 400)]
    [ProducesResponseType(typeof(string), 404)]
    [ProducesResponseType(500)]
    public async Task<IActionResult> UpdateCity(long id, UpdateCityDto updateCity)
    {
        if (updateCity.Id != 0) return BadRequest("Id не должен быть заполнен");
        await _cityService.UpdateCityAsync(id, updateCity);

        return Ok();
    }

    /// <summary>
    /// Удаление города по его идентификатору
    /// </summary>
    /// <param name="id">Идентификатор города</param>
    [HttpDelete("{id}")]
    [ProducesResponseType(200)]
    [ProducesResponseType(typeof(string), 404)]
    [ProducesResponseType(500)]
    public async Task<IActionResult> DeleteCity(long id)
    {
        var _city = await _cityService.GetCityByIdAsync(id);

        if (_city == null) return NotFound("Город не найден");

        await _cityService.DeleteCityAsync(id);

        return Ok();
    }
}