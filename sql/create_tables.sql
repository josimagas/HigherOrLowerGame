CREATE TABLE IF NOT EXISTS Game (
  Id uuid DEFAULT uuid_generate_v4 (),
  FirstPlayerScore INT NOT NULL,
  SecondPlayerScore INT NOT NULL,
  NumberOfCardOnDeck INT NOT NULL,
  CurrentCardValue INT NOT NULL,
  CurrentPlayer VARCHAR,
  Finished boolean NOT NULL,
  CreatedAt VARCHAR NOT NULL,
  Deleted boolean NOT NULL,
  PRIMARY KEY (Id)
);