{
  "openapi": "3.0.1",
  "info": {
    "title": "CarDealership.CarDealership",
    "version": "1.0"
  },
  "paths": {
    "/customer-order/{customerOrderId}": {
      "get": {
        "tags": [
          "CustomerOrder"
        ],
        "parameters": [
          {
            "name": "customerOrderId",
            "in": "path",
            "required": true,
            "schema": {
              "type": "string"
            }
          }
        ],
        "responses": {
          "200": {
            "description": "Success"
          }
        }
      },
      "patch": {
        "tags": [
          "CustomerOrder"
        ],
        "parameters": [
          {
            "name": "customerOrderId",
            "in": "path",
            "required": true,
            "schema": {
              "type": "string"
            }
          }
        ],
        "requestBody": {
          "content": {
            "application/json": {
              "schema": {
                "$ref": "#/components/schemas/CustomerOrderEdit"
              }
            },
            "text/json": {
              "schema": {
                "$ref": "#/components/schemas/CustomerOrderEdit"
              }
            },
            "application/*+json": {
              "schema": {
                "$ref": "#/components/schemas/CustomerOrderEdit"
              }
            }
          }
        },
        "responses": {
          "200": {
            "description": "Success"
          }
        }
      },
      "delete": {
        "tags": [
          "CustomerOrder"
        ],
        "parameters": [
          {
            "name": "customerOrderId",
            "in": "path",
            "required": true,
            "schema": {
              "type": "string"
            }
          }
        ],
        "responses": {
          "200": {
            "description": "Success"
          }
        }
      }
    },
    "/customer-order/status/{status}": {
      "get": {
        "tags": [
          "CustomerOrder"
        ],
        "parameters": [
          {
            "name": "status",
            "in": "path",
            "required": true,
            "schema": {
              "type": "string"
            }
          }
        ],
        "responses": {
          "200": {
            "description": "Success"
          }
        }
      }
    },
    "/customer-order": {
      "post": {
        "tags": [
          "CustomerOrder"
        ],
        "requestBody": {
          "content": {
            "application/json": {
              "schema": {
                "$ref": "#/components/schemas/CustomerOrderCreate"
              }
            },
            "text/json": {
              "schema": {
                "$ref": "#/components/schemas/CustomerOrderCreate"
              }
            },
            "application/*+json": {
              "schema": {
                "$ref": "#/components/schemas/CustomerOrderCreate"
              }
            }
          }
        },
        "responses": {
          "200": {
            "description": "Success"
          }
        }
      }
    },
    "/customer-order/canceled/{customerOrderId}": {
      "patch": {
        "tags": [
          "CustomerOrder"
        ],
        "parameters": [
          {
            "name": "customerOrderId",
            "in": "path",
            "required": true,
            "schema": {
              "type": "string"
            }
          }
        ],
        "responses": {
          "200": {
            "description": "Success"
          }
        }
      }
    },
    "/search/customer/{customerId}": {
      "get": {
        "tags": [
          "Search"
        ],
        "parameters": [
          {
            "name": "customerId",
            "in": "path",
            "required": true,
            "schema": {
              "type": "string"
            }
          }
        ],
        "responses": {
          "200": {
            "description": "Success"
          }
        }
      }
    },
    "/search/employee/{employeeId}": {
      "get": {
        "tags": [
          "Search"
        ],
        "parameters": [
          {
            "name": "employeeId",
            "in": "path",
            "required": true,
            "schema": {
              "type": "string"
            }
          }
        ],
        "responses": {
          "200": {
            "description": "Success"
          }
        }
      }
    },
    "/warehouse/{carId}": {
      "get": {
        "tags": [
          "Warehouse"
        ],
        "parameters": [
          {
            "name": "carId",
            "in": "path",
            "required": true,
            "schema": {
              "type": "string"
            }
          }
        ],
        "responses": {
          "200": {
            "description": "Success"
          }
        }
      }
    },
    "/warehouse/filter": {
      "post": {
        "tags": [
          "Warehouse"
        ],
        "requestBody": {
          "content": {
            "application/json": {
              "schema": {
                "$ref": "#/components/schemas/CarFilter"
              }
            },
            "text/json": {
              "schema": {
                "$ref": "#/components/schemas/CarFilter"
              }
            },
            "application/*+json": {
              "schema": {
                "$ref": "#/components/schemas/CarFilter"
              }
            }
          }
        },
        "responses": {
          "200": {
            "description": "Success"
          }
        }
      }
    },
    "/warehouse-order/{warehouseOrderId}": {
      "get": {
        "tags": [
          "WarehouseOrder"
        ],
        "parameters": [
          {
            "name": "warehouseOrderId",
            "in": "path",
            "required": true,
            "schema": {
              "type": "string"
            }
          }
        ],
        "responses": {
          "200": {
            "description": "Success"
          }
        }
      },
      "delete": {
        "tags": [
          "WarehouseOrder"
        ],
        "parameters": [
          {
            "name": "warehouseOrderId",
            "in": "path",
            "required": true,
            "schema": {
              "type": "string"
            }
          }
        ],
        "responses": {
          "200": {
            "description": "Success"
          }
        }
      }
    },
    "/warehouse-order/status/{status}": {
      "get": {
        "tags": [
          "WarehouseOrder"
        ],
        "parameters": [
          {
            "name": "status",
            "in": "path",
            "required": true,
            "schema": {
              "type": "string"
            }
          }
        ],
        "responses": {
          "200": {
            "description": "Success"
          }
        }
      }
    },
    "/warehouse-order": {
      "post": {
        "tags": [
          "WarehouseOrder"
        ],
        "requestBody": {
          "content": {
            "application/json": {
              "schema": {
                "$ref": "#/components/schemas/WarehouseOrderCreate"
              }
            },
            "text/json": {
              "schema": {
                "$ref": "#/components/schemas/WarehouseOrderCreate"
              }
            },
            "application/*+json": {
              "schema": {
                "$ref": "#/components/schemas/WarehouseOrderCreate"
              }
            }
          }
        },
        "responses": {
          "200": {
            "description": "Success"
          }
        }
      }
    },
    "/warehouse-order/{warehouseOrderId}/employee/{employeeId}": {
      "patch": {
        "tags": [
          "WarehouseOrder"
        ],
        "parameters": [
          {
            "name": "warehouseOrderId",
            "in": "path",
            "required": true,
            "schema": {
              "type": "string"
            }
          },
          {
            "name": "employeeId",
            "in": "path",
            "required": true,
            "schema": {
              "type": "string"
            }
          }
        ],
        "responses": {
          "200": {
            "description": "Success"
          }
        }
      }
    },
    "/warehouse-order/canceled/{warehouseOrderId}": {
      "patch": {
        "tags": [
          "WarehouseOrder"
        ],
        "parameters": [
          {
            "name": "warehouseOrderId",
            "in": "path",
            "required": true,
            "schema": {
              "type": "string"
            }
          }
        ],
        "responses": {
          "200": {
            "description": "Success"
          }
        }
      }
    }
  },
  "components": {
    "schemas": {
      "Car": {
        "type": "object",
        "properties": {
          "make": {
            "type": "string",
            "nullable": true
          },
          "model": {
            "type": "string",
            "nullable": true
          },
          "modelTrim": {
            "type": "string",
            "nullable": true
          },
          "year": {
            "type": "integer",
            "format": "int32"
          }
        },
        "additionalProperties": false
      },
      "CarFilter": {
        "type": "object",
        "properties": {
          "pageSize": {
            "type": "integer",
            "format": "int32"
          },
          "pageNumber": {
            "type": "integer",
            "format": "int32"
          },
          "pageCount": {
            "type": "integer",
            "format": "int32"
          },
          "make": {
            "type": "string",
            "nullable": true
          },
          "model": {
            "type": "string",
            "nullable": true
          },
          "modelTrim": {
            "type": "string",
            "nullable": true
          },
          "year": {
            "type": "integer",
            "format": "int32",
            "nullable": true
          }
        },
        "additionalProperties": false
      },
      "CustomerOrderCreate": {
        "type": "object",
        "properties": {
          "customerId": {
            "type": "string",
            "nullable": true
          },
          "employeeId": {
            "type": "string",
            "nullable": true
          },
          "reservedCarId": {
            "type": "string",
            "nullable": true
          }
        },
        "additionalProperties": false
      },
      "CustomerOrderEdit": {
        "type": "object",
        "properties": {
          "customerId": {
            "type": "string",
            "nullable": true
          },
          "employeeId": {
            "type": "string",
            "nullable": true
          },
          "reservedCarId": {
            "type": "string",
            "nullable": true
          }
        },
        "additionalProperties": false
      },
      "WarehouseOrderCreate": {
        "type": "object",
        "properties": {
          "car": {
            "$ref": "#/components/schemas/Car"
          },
          "employeeId": {
            "type": "string",
            "nullable": true
          }
        },
        "additionalProperties": false
      }
    }
  }
}