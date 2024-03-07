using FluentAssertions;
using PremierLeaguePlayers.Application.Abstractions;
using PremierLeaguePlayers.DataAccess.Repositories;

namespace PremierLeaguePlayers.DataAccess.Tests.Repositories;

public class PlayerRepositoriesTests
{
    private readonly IPlayerRepository _playerRepository;

    public PlayerRepositoriesTests()
    {
        _playerRepository = new PlayerRepository();
    }
    
    [Fact]
    public async void GetidAllPayers_DeserializeJson_ReturnObject()
    {
        // Arrange
        // build expected Player response
        // perhaps create small JSON file inside Tests to represent the large data set
        // then build an expected response from that, otherwise there is too much data
        
        // Act
        var result = await _playerRepository.GetAllPlayers();
        
        // Assert
        result.Should().NotBeNull();
    }
    
    [Fact]
    public async void GetPayerById_DeserializeJson_ReturnPlayerObject()
    {
        // Arrange
        var id = 131;
        
        // Act
        var result = await _playerRepository.GetPlayerById(id);
        
        // Assert
        result.Should().NotBeNull();
    }
    
    [Fact]
    public async void GetRandomPayer_DeserializeJson_ReturnPlayer()
    {
        // Arrange
        
        // Act
        var result = await _playerRepository.GetRandomPlayer();
        
        // Assert
        result.Should().NotBeNull();
    }
}