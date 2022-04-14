# pull official base image
FROM node:13.12.0-alpine

# set working directory
WORKDIR /app
EXPOSE 3000

ARG IMAGE_VERSION
ENV REACT_APP_IMAGE_VERSION = $IMAGE_VERSION
# add `/app/node_modules/.bin` to $PATH
ENV PATH /app/node_modules/.bin:$PATH

# install app dependencies
COPY package.json ./
COPY package-lock.json ./
RUN npm config set unsafe-perm true
RUN npm install --silent
RUN npm install react-scripts@4.0.2 -g --silent

RUN mkdir -p app/node_modules/.cache && chmod -R 777 app/node_modules/.cache

# add app
COPY . ./

# start app
CMD ["npm", "start"]
