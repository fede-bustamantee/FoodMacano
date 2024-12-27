using FoodMacanoServices.Interfaces;
using FoodMacanoServices.Models;

public class UsuarioMappingService
{
    private readonly IGenericService<Usuario> _usuarioService;

    public UsuarioMappingService(IGenericService<Usuario> usuarioService)
    {
        _usuarioService = usuarioService;
    }

    public async Task<Usuario> GetUsuarioByFirebaseId(string firebaseId)
    {
        var usuarios = await _usuarioService.GetAllAsync(u => u.FirebaseId == firebaseId);
        return usuarios?.FirstOrDefault() ??
            throw new InvalidOperationException($"No se encontró usuario con FirebaseId: {firebaseId}");
    }

    public async Task<int> GetUsuarioIdFromFirebaseId(string firebaseId)
    {
        var usuario = await GetUsuarioByFirebaseId(firebaseId);
        return usuario.Id;
    }
}
