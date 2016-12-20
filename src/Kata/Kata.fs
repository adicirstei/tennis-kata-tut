module Kata.Tennis

type Player = 
  | PlayerOne 
  | PlayerTwo


type Point = 
  | Love
  | Fifteen
  | Thirty

type PointsData = {
  PlayerOnePoint : Point
  PlayerTwoPoint : Point
}

type FortyData = {
  Player : Player
  OtherPlayerPoint : Point
}

type Score =
  | Points of PointsData
  | Forty of FortyData
  | Deuce
  | Advantage of Player
  | Game of Player


let scoreWhenDeuce = Advantage 

let scoreWhenAdvantage advatagedPlayer winner = 
  if winner = advatagedPlayer then Game winner
  else Deuce

let other = function 
  | PlayerOne -> PlayerTwo
  | PlayerTwo -> PlayerOne


let scoreWhenForty fd winner =
  let otherPoints = fd.OtherPlayerPoint

  if fd.Player = winner then Game winner
  else 
    match otherPoints with
    |    