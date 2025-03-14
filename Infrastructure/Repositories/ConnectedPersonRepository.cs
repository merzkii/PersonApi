using Application.DTO_s.Person;
using AutoMapper;
using Core.Models;
using Infrastructure.Layer;
using Microsoft.EntityFrameworkCore;

namespace Application.Interfaces
{
    public class ConnectedPersonRepository : IConnectedPersonInterface
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;
        public ConnectedPersonRepository(DataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<int> CreateConnectedPersons(ConnectedPersonDTO connectedPersonDTO)
        {
            if (_context.ConnectedPersons.Any(x =>
             x.ConnectedPersonId == connectedPersonDTO.ConnectedPersonId
             && x.PersonId == connectedPersonDTO.PersonId
             && x.ConnectionType == connectedPersonDTO.ConnectionType))
                throw new InvalidOperationException("Connection Already Exists");

            var connectedperson = _mapper.Map<ConnectedPerson>(connectedPersonDTO);
            _context.ConnectedPersons.Add(connectedperson);
            await _context.SaveChangesAsync();
            return connectedperson.Id;
        }

        public async Task<ConnectedPerson> DeleteConnectedPerson(int id)
        {
            var connectedPerson=await GetConnectedPerson(id);
             _context.ConnectedPersons.Remove(connectedPerson);
            await _context.SaveChangesAsync();
            return connectedPerson;

        }

        public async Task<ConnectedPerson> GetConnectedPerson(int id)
        {
            var connectedPerson = await _context.ConnectedPersons.SingleOrDefaultAsync(c => c.Id == id);
            if (connectedPerson == null)
                throw new InvalidOperationException("Connected Person Not Found");
            return connectedPerson;
        }

        public async Task<ICollection<ConnectedPerson>> GetConnectedPersons()
        {
            return await _context.ConnectedPersons.OrderBy(c => c.Id).ToListAsync(); 
        }

        public async Task<int> UpdateConnectedPerson(UpdateConnectedPersonDTO updateConnectedPersonDTO)
        {
            var existingconnect = await GetConnectedPerson(updateConnectedPersonDTO.Id);
            if (existingconnect == null)
                throw new InvalidOperationException("Connected Person Not Found");
            var connectedperson = _mapper.Map<ConnectedPerson>(updateConnectedPersonDTO);
            _context.Entry(existingconnect).CurrentValues.SetValues(connectedperson);
            await _context.SaveChangesAsync();
            return existingconnect.Id;
        }
    }
}
