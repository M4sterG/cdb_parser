import json
import os
import argparse

def main():
  parser = argparse.ArgumentParser(description="A simple script to dump .dip files into human readable formats like json")
  parser.add_argument("--dest", default="json")
  parser.add_argument("--dip-files", dest="dip_folder", default="dip")
  
  args = parser.parse_args()

  # open the file containing the JSON string list
  with open('files.json', 'r') as f:
      json_str = f.read()

  # parse the JSON string into a list of objects
  file_list = json.loads(json_str)

  # loop through each object in the list
  for file_name in file_list:
    file_path = os.path.join(args.dip_folder, file_name)
    file_size = os.path.getsize(file_path)
    json_file_name = os.path.splitext(file_name)[0] + ".json"
    json_file_name = os.path.join(args.dest, json_file_name)

    dest_dir = os.path.dirname(json_file_name)
    if not os.path.exists(dest_dir):
      os.makedirs(dest_dir)

    with open(file_path, 'rb') as bin_stream:
      print(f"Opening file {file_path}")
      val = bin_stream.read(4)
      key_count =  int.from_bytes(val, byteorder='little', signed=False)

      key_names = []
      key_sizes = []

      for i in range(key_count):
          chunk = bin_stream.read(30).rstrip(b'\x00')
          chunk_str = chunk.decode('utf-8')
          key_names.append(chunk_str)

      for i in range(key_count):
        key_sizes.append(int.from_bytes(bin_stream.read(4), byteorder='little', signed=False))

      header_size = 4 + key_count*34
      data_size = file_size - header_size

      if data_size <= 0:
        print(f"No data, size: {data_size}")
        json_file = open(json_file_name, "w")
        json_file.close()
        continue
      
      block_size = sum(key_sizes)
      if (data_size % block_size == 0):
        loop_for = data_size // block_size

      objects_array = []
      for i in range(loop_for):
        object_data = {}
        for j in range(key_count):
          if key_sizes[j] == 1:
            val = int.from_bytes(bin_stream.read(1), byteorder='little', signed=False)
            object_data[key_names[j]] = True if val == 1 else False
          elif key_sizes[j] == 4:
            val = int.from_bytes(bin_stream.read(4), byteorder='little', signed=False)
            object_data[key_names[j]] = val
          else:
            val = bin_stream.read(key_sizes[j]).rstrip(b'\x00')
            object_data[key_names[j]] = val.decode('utf-8', errors='replace')
        objects_array.append(object_data)

      with open(json_file_name, "w") as json_file:
        json.dump(objects_array, json_file,)
        print(f"Parsed to {json_file_name}")

if __name__ == '__main__':
  main()