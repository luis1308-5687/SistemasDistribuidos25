const express = require('express');
const { ApolloServer, gql } = require('apollo-server-express');
const personas = [
  {
    CI: '123',
    Nombres: 'pepe',
    PrimerApellido: 'cuenca',
    SegundoApellido: 'rios',
    EsBachiller: true,
  },

  {
    CI: '246810',
    Nombres: 'Eric',
    PrimerApellido: 'Barrios',
    SegundoApellido: 'Gonzales',
    EsBachiller: true,
  },

  

];

const typeDefs = gql`
  type Persona {
    CI: String!
    Nombres: String!
    PrimerApellido: String!
    SegundoApellido: String!
    EsBachiller: Boolean!
  }

  type Query {
    persona(ci: String!): Persona
  }
`;

const resolvers = {
  Query: {
    persona: (_, { ci }) => personas.find(p => p.CI === ci),
  },
};

// Servidor
async function startServer() {
  const app = express();
  const server = new ApolloServer({ typeDefs, resolvers });

  await server.start();
  server.applyMiddleware({ app });

  app.listen(4000, () =>
    console.log(`SEDUCA GraphQL ready at http://localhost:4000${server.graphqlPath}`)
  );
}

startServer();
