<div style="text-align: center;">

# 1. I4DAB-HandIn4 

## 1.1. Group 8

<!-- Spacing -->

<br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br>

<!-- /Spacing -->


## 1.2. Participants

| Students                | AUID       | Student number   |
| ----------------------- | ---------- | ---------------- |
| Jakob                   | **TBA**    | **TBA**          |
| Karsten                 | **TBA**    | **TBA**          |
| Kasper Juul Hermansen   | au557919   | 201607110        |
| Martin                  | **TBA**    | **TBA**          |

</div>

<div class="page"></div>

# 2. Table of Contents

<!-- TOC -->

- [1. I4DAB-HandIn4](#1-i4dab-handin4)
    - [1.1. Group 8](#11-group-8)
    - [1.2. Participants](#12-participants)
- [2. Table of Contents](#2-table-of-contents)
- [3. Introduction](#3-introduction)
- [4. What is Mini Smart Grid?](#4-what-is-mini-smart-grid)
    - [4.1. What is our assignment](#41-what-is-our-assignment)
- [5. User stories](#5-user-stories)
- [6. Domain model](#6-domain-model)
- [7. Aggregate diagram](#7-aggregate-diagram)
    - [7.1. Object diagram](#71-object-diagram)
    - [7.2. The databases](#72-the-databases)
        - [7.2.1. Smart Grid Info](#721-smart-grid-info)
        - [7.2.2. Prosumer Info](#722-prosumer-info)
            - [7.2.2.1. Entity-Relation Diagram](#7221-entity-relation-diagram)
            - [7.2.2.2. DS-Diagram](#7222-ds-diagram)
        - [7.2.3. Trader Info](#723-trader-info)
- [8. Overview of Mini Smart Grid API](#8-overview-of-mini-smart-grid-api)
    - [8.1. api/Prosumers](#81-api-prosumers)
    - [8.2. api/TradeInfo](#82-api-tradeinfo)
- [9. The Application](#9-the-application)

<!-- /TOC -->

<div class="page"></div>

# 3. Introduction

This assignment is about a microgrid which can supply energy via connections to several households. These households each is a producer and a consumer, meaning they will produce power from their renewable energy sources, and consume energy. This microgrid is only a smaller part of a larger whole and is connected to a much larger grid or connected to a powerplant where excess energy will be leveraged. Important to the microgrid is that it uses bitcoin and blockchain to handle transactions and cost of energy.

The assignment is to produce a solution which exposes an API that can display information about the microgrid, access each prosumer and handle energy transactions between each prosumer. It is required for the assignment to use three databases, one or more Relational database and one or more NoSQL database. The important part of the application is that it should supply information that will be directly used in bitcoin transactions via blockchain.

<div class="page"></div>

# 4. What is Mini Smart Grid?

Mini Smart Grid is the definition of all the internal components, such as households, connection to the power plant and the mini-grid itself. Mini Smart Grid leverages the power of IoT devices to handle the flow of energy in the system. A household is both a producer and a consumer in this system, meaning that it is a prosumer. Every connection to the Minigrid can be anything from common households to complex companies. But they follow the same rule. A prosumer might produce 5 kWh every timeframe where timeframe is a relative term used to note a frame of time that captures usage energy produced and consumed in that space of time. It might also consume 3 kWh, resulting in an excess 2 kWh of energy. Another household might then via. the mini-grid create a transaction where it takes the excess 2 kWh of energy because it doesn't produce enough energy itself. And the mini-grid will then store the current netto of each connection and each transaction that has taken place, in each timeframe. If the overall system is in excess or lack of energy, it results in it creating a transaction with the connected power plant or another storage method. but, this is trivial for the system, as it calculates cost per. prosumer and can take from the power plant or other storage methods. It is important to note that each transaction will at some point result in the billing of the actual energy used or consumed from the system, this billing is handled via. bitcoin and the blockchain. For example, at the end of the month prosumer x will receive a payment equivalent of 20 kWh from prosumer y, but will have to pay the equivalent of 5 kWh to prosumer z. but, the way it works is that each household pays or receives bitcoin from the centralized Mini Smart Grid, and the last excess or lacks energy will be paid by the individual prosumer through the mini-grid.

## 4.1. What is our assignment

Our task is to produce the API that makes it possible to handle all these different prosumers and transactions. This will be done through an restAPI that is built in _`ASP.NET Core`_ with the help of _SwashBuckle - Swagger_. These APIs will leverage three databases: Smart Grid Info, Prosumer Info and Trader Info. These databases handle different tasks, such as storing Smart Mini Grid information, Prosumer information and transactions.

# 5. User stories

User stories provides an overview over the funktionality an application required, which is from our point of view both the end user, prosumer and the Mini Smart Grid itself.

>1. As a user I should be able to see all the prosumers in the Mini Smart Grid.
>2. As a user I should be able to see all the prosumers transactions in the Mini Smart Grid.
>3. As a user I should be able to see the netto of all the prosumers in the Mini Smart Grid.
>4. As a prosumer I should be able to trade with the Mini Smart Grid.
>5. As a prosumer I should be able to calculate and pay the exact amount of bitcoins to the Mini Smart Grid
>6. As a Mini Smart Grid I should be able to calculate the netto of all transactions in a timeframe.

# 6. Domain model

>*_TBA_*

# 7. Aggregate diagram

>*_TBA_*

## 7.1. Object diagram

>*_TBA_*


## 7.2. The databases

> Insert Picture of all three databases in polyglot persistance.

The solution contains three databases, which are specified below. This application uses Polyglot persistense, meaning that the domain model is fulfilled with a number of databases, each chosen for their strengths in the specific situation.

### 7.2.1. Smart Grid Info

Smart Grid Info is a noSQL database and more specifically a Cosmos SQL API database. The database contains documents, and every document accounts for a single Smart Mini Grid system. where it contains an ID for the Smart Mini Grid and a collection of prosumers, and a total netto of all the energy transactions that has taken place in the mini grid.

### 7.2.2. Prosumer Info

Prosumer Info is a relational SQL database containing information about prosumers and stores information such as an ID for the prosumer, an address and a type. This database ties the transactions to a household and connects it to the overall smart mini grid.

#### 7.2.2.1. Entity-Relation Diagram

>*_TBA_*

#### 7.2.2.2. DS-Diagram

>*_TBA_*

### 7.2.3. Trader Info

Trader Info is a noSQL database and as Smart Grid Info is a Cosmos SQL API database, where every document is a transaction between households through the mini grid.

# 8. Overview of Mini Smart Grid API

APIs provide an easy way for applications to utilize HTTP to connect and use a foreign system. This is especially useful for systems where end system (Client system) may be written in either a different programming language, or the API be public and the endpoint of the application. This is the way the Mini Smart Grid API is implemnted as it provides easy access to vital data, without having to bother with webpages and presentation.

## 8.1. api/Prosumers

>*_TBA_*

## 8.2. api/TradeInfo

>*_TBA_*

# 9. The Application

As mentioned before, the application is written in C# with the framework ASP.NET Core 2.0, using the Web API preset. This means that the view of the MVC (Model-View-Controller) framework is a JSON or XML string (we only implemented JSON).The application handles HTTP Requests with methods, such as `POST`, `PUT`, `GET` and `DELETE`. This enables our application to follow CRUD principles (Create, Read, Update and Delete). Because we implemt these methods via HTTP requests, our controller has to stay stateless.