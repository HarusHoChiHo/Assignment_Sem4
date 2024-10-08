import tensorflow as tf

keras_model =tf.keras.models.load_model (r"./keras_model.keras")
# Convert the model
converter = tf.lite.TFLiteConverter.from_keras_model(keras_model) # path to the SavedModel directory
tflite_model = converter.convert()

# Save the model.
with open('model1.tflite', 'wb') as f:
  f.write(tflite_model)

