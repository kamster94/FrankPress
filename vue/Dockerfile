FROM node:lts-alpine

WORKDIR /app

COPY package.json /app/package.json

RUN npm install
RUN npm install @quasar/cli -g
COPY . ./app

# start app
CMD ["quasar", "dev"]