﻿using Application.DTO_s.Person;
using Application.Extensions;
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

        public async Task<int> CreateConnections(ConnectedPersonDTO connectedPersonDTO)
        {
            if (_context.ConnectedPersons.Any(x =>
                (x.ConnectedPersonId == connectedPersonDTO.ConnectedPersonId && x.PersonId == connectedPersonDTO.PersonId && x.ConnectionType == connectedPersonDTO.ConnectionType) ||
                (x.ConnectedPersonId == connectedPersonDTO.PersonId && x.PersonId == connectedPersonDTO.ConnectedPersonId && x.ConnectionType == connectedPersonDTO.ConnectionType)))
            {
                throw new InvalidOperationException("Connection Already Exists");
            }

            var connectedperson = _mapper.Map<ConnectedPerson>(connectedPersonDTO);
            _context.ConnectedPersons.Add(connectedperson);
            await _context.SaveChangesAsync();
            return connectedperson.Id;
        }

        public async Task<int> DeleteConnection(int id)
        {
            var connectedPerson = await _context.ConnectedPersons.FindAsync(id);
            if (connectedPerson == null)
                throw new InvalidOperationException("Connected Person Not Found");
            _context.ConnectedPersons.Remove(connectedPerson);
            await _context.SaveChangesAsync();
            return connectedPerson.Id;

        }

        public async Task<GetConnectedPersonsDTO> GetConnection(int id)
        {
            var connectedPerson = await _context.ConnectedPersons.SingleOrDefaultAsync(c => c.Id == id);
            if (connectedPerson == null)
                throw new InvalidOperationException("Connected Person Not Found");
            return connectedPerson.CreateDTO();
        }

        public async Task<List<GetConnectedPersonsDTO>> GetConnections()
        {
            var connectedPersons = await _context.ConnectedPersons.OrderBy(c => c.Id).ToListAsync();
            return connectedPersons.Select(c => c.CreateDTO()).ToList();
        }

        //public async Task<int> UpdateConnectedPerson(UpdateConnectedPersonDTO updateConnectedPersonDTO)
        //{
        //    var existingconnect = await _context.ConnectedPersons.FindAsync(updateConnectedPersonDTO.Id);
        //    if (existingconnect == null)
        //        throw new InvalidOperationException("Connected Person Not Found");
        //    if (_context.ConnectedPersons.Any(x =>
        //         (x.ConnectedPersonId == updateConnectedPersonDTO.ConnectedPersonId && x.PersonId == updateConnectedPersonDTO.PersonId && x.ConnectionType == updateConnectedPersonDTO.ConnectionType) ||
        //         (x.ConnectedPersonId == updateConnectedPersonDTO.PersonId && x.PersonId == updateConnectedPersonDTO.ConnectedPersonId && x.ConnectionType == updateConnectedPersonDTO.ConnectionType)))
        //    {
        //        throw new InvalidOperationException("Connection Already Exists");
        //    }
        //    var connectedperson = _mapper.Map<ConnectedPerson>(updateConnectedPersonDTO);
        //    _context.Entry(existingconnect).CurrentValues.SetValues(connectedperson);
        //    await _context.SaveChangesAsync();
        //    return existingconnect.Id;
        //}
    }
}
