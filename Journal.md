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
    - [4.1. What is our assignment?](#41-what-is-our-assignment)
- [5. Overview of APIs](#5-overview-of-apis)
    - [5.1. Smart Grid Info](#51-smart-grid-info)
    - [5.2. Prosumer Info](#52-prosumer-info)
    - [5.3. Trader Info](#53-trader-info)

<!-- /TOC -->

<div class="page"></div>

# 3. Introduction

This assignment is about a microgrid, that can supply and connect to a number of households. These households each is a producer and a consumer, meaning that they will produce power from their renewable energy sources, and consume energy. This microgrid is only a smaller part of a larger whole and is either connected to a much larger grid og connected to a powerplant, where excess energy can be leveraged. Important to the microgrid is that it utilizes bitcoin and blockchain to handle transactions and cost of energy.

The assignment is to produce a solution which provide an API that can display information about the microgrid as a whole, access each prosumer and handle energy transactions between each prosumer. The assignment is required to use three databases, one or more Relational database and one or more NoSQL Database.The important part of the application is that it should supply information that can directly be used in bitcoin transactions via. blockchain.

<div class="page"></div>

# 4. What is Mini Smart Grid?

Mini Smart Grid is the definition of all the internal components, such as households, connection to the powerplant and the mini grid itself. Mini Smart Grid leverages the power of IoT devices to handle the flow of energy in the system. A household is both a producer and a consumer in this system, meaning that it is a prosumer. Every connection to the Minigrid can be anything from common households to complex companies. But they follow the same rule. A prosumer might produce 5 kWh every timeframe, where timeframe is a relative term used to note a frame of time that captures usage energy produced and consumed in that space of time. It might also consume 3 kWh, resulting in an excess 2 kWh of energy. Another household might then via. the minigrid create a transaction where it takes the excess 2 kWh of energy, because it doesn't produce enough energy itself. And the minigrid will then store the current netto of each connection and each transaction that has taken place, in a given timeframe. If the overall system is in excess or lack of energy, it might result in it creating a transaction with the connected powerplant or another storage method. However, this is trivial for the system, as it calculates cost pr. prosumer and can freely take from the powerplant or other storage method. It is important to note that each transaction will at some point result in the billing of the actual energy used or consumed from the system, this billing is handled via. bitcoin and the block chain. For example at the end of the month prosumer x will receive payment equivalent of 20 kWh from prosumer y, but will have to pay the equaivalent of 5 kWh to prosumer z. However the way it works is that each house hold pays or receives bitcoin from the centralized Mini Smart Grid, and the last excess or lacks of energy will be paid by the individual prosumer through the mini grid.

## 4.1. What is our assignment?

Our task is to produce the API that makes it possible to handle all these different prosumers and transactions. This will be done through an restAPI that is built in `ASP.NET Core` with the help of `SwashBuckle - Swagger`. 

# 5. Overview of APIs

## 5.1. Smart Grid Info

## 5.2. Prosumer Info

## 5.3. Trader Info
