-- Schema

CREATE TABLE IF NOT EXISTS yatzy.player (
    id INT AUTO_INCREMENT PRIMARY KEY,
    name VARCHAR(50) NOT NULL,
    active TINYINT DEFAULT 1,
    UNIQUE INDEX index_name (name)
);

CREATE TABLE IF NOT EXISTS yatzy.game (
    id INT AUTO_INCREMENT PRIMARY KEY,
    played DATE NOT NULL
);

CREATE TABLE IF NOT EXISTS yatzy.result (
    id INT AUTO_INCREMENT PRIMARY KEY,
    game INT, 
    player INT, 
    position INT NOT NULL,
    score INT NOT NULL,
    yatzy BOOL NOT NULL,
    CONSTRAINT `fk_result_game` FOREIGN KEY (game) REFERENCES game (id),
    CONSTRAINT `fk_result_player` FOREIGN KEY (player) REFERENCES player (id)
);

-- Test data

INSERT IGNORE INTO yatzy.player (id, name, active) VALUES (1, "John Doe", 1);
INSERT IGNORE INTO yatzy.player (id, name, active) VALUES (2, "Jane Doe", 0);
INSERT IGNORE INTO yatzy.player (id, name, active) VALUES (3, "Test", 1);

INSERT IGNORE INTO yatzy.game (id, played) VALUES (1, "2022-02-21");
INSERT IGNORE INTO yatzy.result (game, player, position, score, yatzy) VALUES (1, 1, 1, 311, TRUE);
INSERT IGNORE INTO yatzy.result (game, player,  position, score, yatzy) VALUES (1, 2, 2, 235, FALSE);

INSERT IGNORE INTO yatzy.game (id, played) VALUES (2, "2022-02-23");
INSERT IGNORE INTO yatzy.result (game, player, position, score, yatzy) VALUES (2, 1, 1, 249, FALSE);
INSERT IGNORE INTO yatzy.result (game, player,  position, score, yatzy) VALUES (2, 2, 2, 136, FALSE);

INSERT IGNORE INTO yatzy.game (id, played) VALUES (3, "2022-02-23");
INSERT IGNORE INTO yatzy.result (game, player, position, score, yatzy) VALUES (3, 1, 1, 190, FALSE);
INSERT IGNORE INTO yatzy.result (game, player,  position, score, yatzy) VALUES (3, 2, 2, 183, FALSE);

INSERT IGNORE INTO yatzy.game (id, played) VALUES (4, "2022-02-23");
INSERT IGNORE INTO yatzy.result (game, player, position, score, yatzy) VALUES (4, 1, 1, 228, FALSE);
INSERT IGNORE INTO yatzy.result (game, player,  position, score, yatzy) VALUES (4, 2, 2, 157, FALSE);

INSERT IGNORE INTO yatzy.game (id, played) VALUES (5, "2022-02-25");
INSERT IGNORE INTO yatzy.result (game, player, position, score, yatzy) VALUES (5, 1, 1, 279, FALSE);
INSERT IGNORE INTO yatzy.result (game, player,  position, score, yatzy) VALUES (5, 2, 2, 268, FALSE);

INSERT IGNORE INTO yatzy.game (id, played) VALUES (6, "2022-02-25");
INSERT IGNORE INTO yatzy.result (game, player, position, score, yatzy) VALUES (6, 1, 2, 169, FALSE);
INSERT IGNORE INTO yatzy.result (game, player,  position, score, yatzy) VALUES (6, 2, 1, 226, FALSE);

INSERT IGNORE INTO yatzy.game (id, played) VALUES (7, "2022-02-25");
INSERT IGNORE INTO yatzy.result (game, player, position, score, yatzy) VALUES (7, 1, 1, 217, FALSE);
INSERT IGNORE INTO yatzy.result (game, player,  position, score, yatzy) VALUES (7, 2, 2, 207, FALSE);

INSERT IGNORE INTO yatzy.game (id, played) VALUES (8, "2022-02-26");
INSERT IGNORE INTO yatzy.result (game, player, position, score, yatzy) VALUES (8, 1, 2, 243, FALSE);
INSERT IGNORE INTO yatzy.result (game, player,  position, score, yatzy) VALUES (8, 2, 1, 257, FALSE);

INSERT IGNORE INTO yatzy.game (id, played) VALUES (9, "2022-02-26");
INSERT IGNORE INTO yatzy.result (game, player, position, score, yatzy) VALUES (9, 1, 2, 183, TRUE);
INSERT IGNORE INTO yatzy.result (game, player,  position, score, yatzy) VALUES (9, 2, 1, 228, FALSE);

INSERT IGNORE INTO yatzy.game (id, played) VALUES (10, "2022-02-27");
INSERT IGNORE INTO yatzy.result (game, player, position, score, yatzy) VALUES (10, 1, 2, 250, TRUE);
INSERT IGNORE INTO yatzy.result (game, player,  position, score, yatzy) VALUES (10, 2, 1, 274, TRUE);

INSERT IGNORE INTO yatzy.game (id, played) VALUES (11, "2022-02-27");
INSERT IGNORE INTO yatzy.result (game, player, position, score, yatzy) VALUES (11, 1, 1, 244, FALSE);
INSERT IGNORE INTO yatzy.result (game, player,  position, score, yatzy) VALUES (11, 2, 2, 203, FALSE);

INSERT IGNORE INTO yatzy.game (id, played) VALUES (12, "2022-02-27");
INSERT IGNORE INTO yatzy.result (game, player, position, score, yatzy) VALUES (12, 1, 2, 237, TRUE);
INSERT IGNORE INTO yatzy.result (game, player,  position, score, yatzy) VALUES (12, 2, 1, 259, TRUE); 

INSERT IGNORE INTO yatzy.game (id, played) VALUES (13, "2022-03-04");
INSERT IGNORE INTO yatzy.result (game, player, position, score, yatzy) VALUES (13, 1, 1, 267, TRUE);
INSERT IGNORE INTO yatzy.result (game, player,  position, score, yatzy) VALUES (13, 2, 2, 241, TRUE); 

INSERT IGNORE INTO yatzy.game (id, played) VALUES (14, "2022-03-04");
INSERT IGNORE INTO yatzy.result (game, player, position, score, yatzy) VALUES (14, 1, 1, 267, FALSE);
INSERT IGNORE INTO yatzy.result (game, player,  position, score, yatzy) VALUES (14, 2, 2, 233, FALSE); 

INSERT IGNORE INTO yatzy.game (id, played) VALUES (15, "2022-03-04");
INSERT IGNORE INTO yatzy.result (game, player, position, score, yatzy) VALUES (15, 1, 2, 181, FALSE);
INSERT IGNORE INTO yatzy.result (game, player,  position, score, yatzy) VALUES (15, 2, 1, 221, TRUE); 

-- Grants

GRANT ALL PRIVILEGES ON `yatzy`.* TO `yatzy`@`%`;
