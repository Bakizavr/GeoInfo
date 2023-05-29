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
    [ProducesResponseType(typeof(CityDto), 200)]
    [ProducesResponseType(typeof(string), 404)]
    [ProducesResponseType(500)]
    public async Task<ActionResult<CityDto>> GetCityById(long id, CancellationToken cancellationToken)
    {
        var city = await _cityService.GetCityByIdAsync(id, cancellationToken);

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
    [ProducesResponseType(typeof(CollectionViewModel<CityDto>), 200)]
    [ProducesResponseType(typeof(string), 400)]
    [ProducesResponseType(typeof(string), 404)]
    [ProducesResponseType(500)]
    public async Task<ActionResult<CollectionViewModel<CityDto>>> GetPageIndex(int page, int pageSize, CancellationToken cancellationToken)
    {
        var dto = await _cityService.GetPageAsync(page, pageSize, cancellationToken);

        return Ok(dto);
    }

    /// <summary>
    /// Получение двух городов по названию
    /// </summary>
    /// <param name="name1">Название первого города</param>
    /// <param name="name2">Название второго города</param>
    /// <returns>Информация о городах</returns>
    [HttpGet("{name1}/{name2}")]
    [ProducesResponseType(typeof(IEnumerable<CityDto>), 200)]
    [ProducesResponseType(typeof(string), 400)]
    [ProducesResponseType(typeof(string), 404)]
    [ProducesResponseType(500)]
    public async Task<ActionResult<IEnumerable<CityDto>>> GetTwoCities(string name1, string name2, CancellationToken cancellationToken)
    {
        var cities = await _cityService.GetTwoCitiesAsync(name1, name2, cancellationToken);

        if (cities.Data.Any() == false) return NotFound("Города не найдены");

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
    public async Task<ActionResult<long>> CreateCity(CreateCityDto createCity, CancellationToken cancellationToken)
    {
        var cityId = await _cityService.CreateCityAsync(createCity, cancellationToken);

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
    public async Task<IActionResult> UpdateCity(long id, UpdateCityDto updateCity, CancellationToken cancellationToken)
    {
        try
        {
            await _cityService.UpdateCityAsync(id, updateCity, cancellationToken);
        }
        catch (Exception ex)
        {
            return NotFound(ex.Message);
        }

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
    public async Task<IActionResult> DeleteCity(long id, CancellationToken cancellationToken)
    {
        try
        {
            await _cityService.DeleteCityAsync(id, cancellationToken);
        }
        catch(NotFoundException ex)
        {
            return NotFound(ex.Message);
        }
        return Ok();
    }
}